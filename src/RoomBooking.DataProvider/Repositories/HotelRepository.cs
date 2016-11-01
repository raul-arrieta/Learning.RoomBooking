using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.DataProvider.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}