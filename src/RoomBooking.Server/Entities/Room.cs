using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.NetCore.Angular2.Entities.Abstract;

namespace RoomBooking.Entities
{
    public class Room: IEntityBase
    {
        public Room()
        {
            RoomBookings = new List<RoomBooking>();
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public RoomType RoomType { get; set; }
        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }

    public enum RoomType
    {
        Single = 1,
        Double = 2,
        Studio = 3,
        Suite = 4
    }
}
