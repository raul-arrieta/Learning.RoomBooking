using System;
using System.Collections.Generic;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Shared.Entities
{
    public class Hotel : IEntityBase
    {
        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        public Guid Id { get; set; }
    }
}