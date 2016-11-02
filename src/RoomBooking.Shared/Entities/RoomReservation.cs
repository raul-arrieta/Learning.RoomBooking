using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Shared.Entities
{
    public class RoomReservation: IEntityBase
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Room Room { get; set; }
    }
}
