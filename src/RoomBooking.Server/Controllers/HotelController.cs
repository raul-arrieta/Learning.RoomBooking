using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.DataProvider.Repositories;
using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Manager;
using RoomBooking.Models;
using RoomBooking.Shared.Core;
using RoomBooking.Shared.Entities;
using RoomBooking.Manager.Abstract;

namespace HotelHoteling.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private readonly HotelManager<Hotel, IHotelRepository> _hotelManager;

        public HotelController(IHotelRepository hotelRepository, IErrorRepository errorRepository)
        {
            _hotelManager = new HotelManager<Hotel, IHotelRepository>(hotelRepository, errorRepository);
        }

        [HttpGet("{page:int=0}/{pageSize=12}")]
        public PaginationSet<HotelViewModel> Get(int? page, int? pageSize)
        {
            var currentPage = page ?? 0;
            var currentPageSize = pageSize ?? 12;
            int totalHotels;
            var hotels = _hotelManager.GetHotels(page, pageSize, out totalHotels);

            return new PaginationSet<HotelViewModel>
            {
                Page = currentPage,
                TotalCount = totalHotels,
                TotalPages = (int) Math.Ceiling((decimal) totalHotels/currentPageSize),
                Items = Mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelViewModel>>(hotels)
            };
        }

        [HttpGet("{id:Guid}")]
        public HotelViewModel Get(Guid? id)
        {
            return Mapper.Map<Hotel, HotelViewModel>(_hotelManager.Get(id));
        }


        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            return new ObjectResult(_hotelManager.Delete(id));
        }
    }
}