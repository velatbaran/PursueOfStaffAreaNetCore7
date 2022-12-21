using Microsoft.EntityFrameworkCore;
using PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract;
using PursueOfStaffAreaNetCore7.DataAccessLayer.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.AnyAsync(filter);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _dbSet.FindAsync(filter);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            //_dbSet.Update(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;

        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.Where(filter);
        }
    }
}
