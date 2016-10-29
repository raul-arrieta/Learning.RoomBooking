using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Shared.Extensions
{
    public static class Extensions
    {
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }

        public static bool IsNull<T>(this T? obj) where T : struct
        {
            return !obj.HasValue;
        }

        public static int CountOrNull<T>(this IEnumerable<T> obj)
        {
            return obj.IsNull() ? 0 : obj.Count();
        }
    }
}

