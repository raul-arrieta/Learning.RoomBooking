using System;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Shared.Entities
{
    public class Error : IEntityBase
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid Id { get; set; }
    }
}