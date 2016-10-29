using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomBooking.Shared.Extensions;

namespace RoomBooking.Shared.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Count => Items.CountOrNull();
    }
}
