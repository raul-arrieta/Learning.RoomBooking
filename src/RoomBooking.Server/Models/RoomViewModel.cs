using System;

namespace RoomBooking.Models
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
        public string Hotel { get; set; }
        public Guid HotelId { get; set; }
    }
}