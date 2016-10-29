using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.NetCore.Angular2.Entities.Abstract;

namespace RoomBooking.Entities
{
    public class Hotel : IEntityBase
    {
        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int ZipCode { get; set; }
        public String Country { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
