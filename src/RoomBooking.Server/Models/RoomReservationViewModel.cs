using System;

namespace RoomBooking.Models
{
    public class RoomReservationViewModel
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Room { get; set; }
        public Guid RoomId { get; set; }
        public string Hotel { get; set; }
        public Guid HotelId { get; set; }
    }
}