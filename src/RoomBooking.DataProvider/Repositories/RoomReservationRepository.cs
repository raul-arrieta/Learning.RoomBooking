using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.DataProvider.Repositories
{
    public class RoomReservationRepository : BaseRepository<RoomReservation>, IRoomReservationRepository
    {
        public RoomReservationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}