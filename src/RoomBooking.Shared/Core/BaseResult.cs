using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Shared.Core
{
    public class BaseResult
    {
        public bool Succees { get; set; }
        public string Message { get; set; }
    }
}
