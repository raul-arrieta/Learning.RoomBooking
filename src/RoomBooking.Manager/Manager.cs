using System;
using System.Collections.Generic;
using System.Linq;
using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Manager.Abstract;
using RoomBooking.Shared.Core;
using RoomBooking.Shared.Entities;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Manager
{
    public class Manager<T, TRepo> : IManager<T,TRepo>
        where T : class, IEntityBase, new()
        where TRepo : class, IBaseRepository<T>
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IBaseRepository<T> _repository;

        public Manager(TRepo repository, IErrorRepository errorRepository)
        {
            _repository = repository;
            _errorRepository = errorRepository;
        }

        public List<T> Get(int? page, int? pageSize, out int totalCount)
        {
            var results = new List<T>();
            totalCount = 0;
            try
            {
                var currentPage = page ?? 0;
                var currentPageSize = pageSize ?? 12;

                results = _repository
                    .AllIncluding(p => p.AllIncludingParams)
                    .OrderBy(p => p.Id)
                    .Skip(currentPage*currentPageSize)
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

        public T Get(Guid? id)
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

        public BaseResult Delete(Guid id)
        {
            BaseResult removeResult;
            try
            {
                var recordToRemove = _repository.GetSingle(id);
                _repository.Delete(recordToRemove);
                _repository.Commit();

                removeResult = new BaseResult
                {
                    Succees = true,
                    Message = "Succesfully removed."
                };
            }
            catch (Exception ex)
            {
                removeResult = new BaseResult
                {
                    Succees = false,
                    Message = ex.Message
                };

                _errorRepository.Add(new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                });
                _errorRepository.Commit();
            }

            return removeResult;
        }
    }
}