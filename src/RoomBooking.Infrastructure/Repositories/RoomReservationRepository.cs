using RoomBooking.Infrastructure.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Infrastructure.Repositories
{
    public class RoomReservationRepository : BaseRepository<RoomReservation>, IRoomReservationRepository
    {
        public RoomReservationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}