﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null);
    }
}
