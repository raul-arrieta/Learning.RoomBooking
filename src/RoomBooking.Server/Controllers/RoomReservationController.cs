using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Manager;
using RoomBooking.Manager.Abstract;
using RoomBooking.Models;
using RoomBooking.Shared.Core;
using RoomBooking.Shared.Entities;

namespace RoomReservationBooking.Controllers
{
    [Route("api/[controller]")]
    public class RoomReservationController : Controller
    {
        private readonly IManager<RoomReservation, IRoomReservationRepository> _manager;

        public RoomReservationController(IRoomReservationRepository roomReservationRepository,
            IErrorRepository errorRepository)
        {
            _manager = new ManagerBase<RoomReservation, IRoomReservationRepository>(roomReservationRepository,
                errorRepository);
        }

        [HttpGet("{page:int=0}/{pageSize=12}")]
        public PaginationSet<RoomReservationViewModel> Get(int? page, int? pageSize)
        {
            var currentPage = page ?? 0;
            var currentPageSize = pageSize ?? 12;
            int totalRoomReservations;
            var roomReservations = _manager.Get(page, pageSize, out totalRoomReservations);

            return new PaginationSet<RoomReservationViewModel>
            {
                Page = currentPage,
                TotalCount = totalRoomReservations,
                TotalPages = (int) Math.Ceiling((decimal) totalRoomReservations/currentPageSize),
                Items =
                    Mapper.Map<IEnumerable<RoomReservation>, IEnumerable<RoomReservationViewModel>>(roomReservations)
            };
        }

        [HttpGet("{id:Guid}")]
        public RoomReservationViewModel Get(Guid? id)
        {
            return Mapper.Map<RoomReservation, RoomReservationViewModel>(_manager.Get(id));
        }


        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            return new ObjectResult(_manager.Delete(id));
        }
    }
}