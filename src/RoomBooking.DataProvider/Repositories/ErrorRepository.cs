using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Entities;

namespace RoomBooking.DataProvider.Repositories
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