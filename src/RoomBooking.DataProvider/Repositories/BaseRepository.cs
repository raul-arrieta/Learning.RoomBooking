using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RoomBooking.DataProvider.Repositories.Abstract;
using RoomBooking.Shared.Entities.Abstract;

namespace RoomBooking.DataProvider.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntityBase, new()
    {
        private readonly ApplicationContext _context;

        #region Properties

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        #endregion

        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Commit() => _context.SaveChanges();

        #region GetAll

        public virtual IEnumerable<T> GetAll() => _context.Set<T>().AsEnumerable();

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        #endregion

        #region AllIncluding

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
            return query.AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> AllIncludingAsync(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);
            return await query.ToListAsync();
        }

        #endregion

        #region GetSingle

        public T GetSingle(Guid id) => _context.Set<T>().FirstOrDefault(x => x.Id == id);

        public T GetSingle(Expression<Func<T, bool>> predicate) => _context.Set<T>().FirstOrDefault(predicate);

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            return query.Where(predicate).FirstOrDefault();
        }

        public async Task<T> GetSingleAsync(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        #endregion

        #region FindBy

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate);

        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();

        #endregion
    }
}