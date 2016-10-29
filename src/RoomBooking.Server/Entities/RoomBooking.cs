using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learning.NetCore.Angular2.Entities.Abstract;

namespace RoomBooking.Entities
{
    public class RoomBooking: IEntityBase
    {
        public Guid Id { get; set; }
        public String ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Room { get; set; }
    }
}
