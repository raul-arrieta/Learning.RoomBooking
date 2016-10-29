using RoomBooking.Infrastructure.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Infrastructure.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}