using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.Infrastructure.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class, IEntityBase, new()
    {
        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void Commit();

        #region GetAll

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        #endregion

        #region AllIncluding

        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        #endregion

        #region GetSingle

        T GetSingle(Guid id);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetSingleAsync(Guid id);

        #endregion

        #region FindBy

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        #endregion
    }
}