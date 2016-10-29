using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
