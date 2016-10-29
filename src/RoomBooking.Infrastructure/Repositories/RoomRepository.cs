using RoomBooking.Infrastructure.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Infrastructure.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
