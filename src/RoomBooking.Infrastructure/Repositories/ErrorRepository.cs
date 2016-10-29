using RoomBooking.Infrastructure.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.Infrastructure.Repositories
{
    public class ErrorRepository : BaseRepository<Error>, IErrorRepository
    {
        public ErrorRepository(ApplicationContext context)
            : base(context)
        {
        }

        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch
            {
                // ignored
            }
        }
    }
}