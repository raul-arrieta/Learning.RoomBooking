using System;
using System.Collections.Generic;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Shared.Entities
{
    public class Room : IEntityBase
    {
        public Room()
        {
            RoomReservations = new List<RoomReservation>();
        }

        public string Name { get; set; }
        public RoomType RoomType { get; set; }
        public Hotel Hotel { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }

        public Guid Id { get; set; }
    }

    public enum RoomType
    {
        Single = 1,
        Double = 2,
        Studio = 3,
        Suite = 4
    }
}