using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Infrastructure.Repositories.Abstract;
using RoomBooking.Manager;
using RoomBooking.Models;
using RoomBooking.Shared.Core;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly Manager<Room, IRoomRepository> _manager;

        public RoomController(IRoomRepository roomRepository, IErrorRepository errorRepository)
        {
            _manager = new Manager<Room, IRoomRepository>(roomRepository, errorRepository);
        }

        [HttpGet("{page:int=0}/{pageSize=12}")]
        public PaginationSet<RoomViewModel> Get(int? page, int? pageSize)
        {
            var currentPage = page ?? 0;
            var currentPageSize = pageSize ?? 12;
            int totalRooms;

            var rooms = _manager.Get(page, pageSize, out totalRooms);


            return new PaginationSet<RoomViewModel>
            {
                Page = currentPage,
                TotalCount = totalRooms,
                TotalPages = (int) Math.Ceiling((decimal) totalRooms/currentPageSize),
                Items = Mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(rooms)
            };
        }

        [HttpGet("{id:Guid}")]
        public RoomViewModel Get(Guid? id)
        {
            return Mapper.Map<Room, RoomViewModel>(_manager.Get(id));
        }


        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            return new ObjectResult(_manager.Delete(id));
        }
    }
}