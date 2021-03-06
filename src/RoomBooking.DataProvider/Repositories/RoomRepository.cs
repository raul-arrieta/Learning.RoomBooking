﻿using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.DataProvider.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}