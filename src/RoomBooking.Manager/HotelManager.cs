using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Entities;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Manager
{
    public class HotelManager<T, TRepo> : ManagerBase<T,TRepo>
        where T : class, IEntityBase, new()
        where TRepo : class, IBaseRepository<T>
    {
        internal readonly IHotelRepository _hotelRepository;
        public HotelManager(TRepo repository, IErrorRepository errorRepository) : base(repository, errorRepository)
        {
            _hotelRepository = (IHotelRepository) repository;
        }

        public List<Hotel> GetHotels(int? page, int? pageSize, out int totalCount)
        {
            var results = new List<Hotel>();
            totalCount = 0;
            try
            {
                var currentPage = page ?? 0;
                var currentPageSize = pageSize ?? 12;

                results = _hotelRepository
                    .AllIncluding(hotel => hotel.Rooms)
                    .OrderBy(p => p.Id)
                    .Skip(currentPage * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

                totalCount = _repository.GetAll().Count();
            }
            catch (Exception ex)
            {
                _errorRepository.Add(new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                });
                _errorRepository.Commit();
            }
            return results;
        }

        public virtual T Get(Guid? id)
        {
            var result = new T();
            try
            {
                result = _repository.GetSingle(r => r.Id == id);
            }
            catch (Exception ex)
            {
                _errorRepository.Add(new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                });
                _errorRepository.Commit();
            }

            return result;
        }
    }
}
