using System;

namespace RoomBooking.Models
{
    public class HotelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalRooms { get; set; }
        public int TotalRoomReservations { get; set; }
    }
}