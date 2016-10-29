using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RoomBooking.Shared.Entities;
using RoomBooking.Shared.Extensions;

namespace RoomBooking.Infrastructure
{
    public static class DbInitializer
    {
        private static ApplicationContext _context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (ApplicationContext)serviceProvider.GetService(typeof(ApplicationContext));
            InitializeContext();
        }

        private static void InitializeContext()
        {
            if (_context.Hotels.Any())
                return;

            var hotels = new List<Hotel>()
            {
                _context.Hotels.Add(new Hotel {Name = "Hotel #1"}).Entity,
                _context.Hotels.Add(new Hotel {Name = "Hotel #2"}).Entity,
                _context.Hotels.Add(new Hotel {Name = "Hotel #3"}).Entity
            };

            hotels.ForEach(h => {
                for (var i = 0; i <= 15; i++)
                {
                    h.Rooms.Add(_context.Rooms.Add(new Room
                    {
                        Name = string.Format("{0} - Room #{1}", h.Name, i),
                        RoomType = RoomType.Single,
                        Hotel = h
                    }).Entity);
                }
            });
                
            _context.SaveChanges();
        }
        
    }
}
