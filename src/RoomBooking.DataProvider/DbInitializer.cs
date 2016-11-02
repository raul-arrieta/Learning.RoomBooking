using System;
using System.Collections.Generic;
using System.Linq;
using RoomBooking.Shared.Entities;

namespace RoomBooking.DataProvider
{
    public static class DbInitializer
    {
        private static ApplicationContext context;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (ApplicationContext) serviceProvider.GetService(typeof(ApplicationContext));
            InitializeContext();
        }

        private static void InitializeContext()
        {
            context.Database.EnsureCreated();

            if (context.Hotels.Any())
                return;

            var hotels = new List<Hotel>
            {
                context.Hotels.Add(new Hotel {Name = "Hotel #1", Address = "135 Brook Drive Lagrange, 30240"}).Entity,
                context.Hotels.Add(new Hotel {Name = "Hotel #2", Address = "5 Ivy Ave. Bettendorf, 52722"}).Entity,
                context.Hotels.Add(new Hotel {Name = "Hotel #3", Address = "759 Thompson Dr. Eastlake, 44095"}).Entity
            };

            hotels.ForEach(h =>
            {
                for (var i = 0; i <= 15; i++)
                    h.Rooms.Add(context.Rooms.Add(new Room
                    {
                        Name = string.Format("{0} - Room #{1}", h.Name, i),
                        RoomType = RoomType.Single,
                        Hotel = h
                    }).Entity);
            });

            context.SaveChanges();
        }
    }
}