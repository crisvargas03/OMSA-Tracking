using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Data;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OMSATrackingAPI.DAL.Repository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MainDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MainDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, 
            bool tracked = true,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            
            query = ApplyIncludes(query, includes);
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, 
            bool tracked = true,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            
            query = ApplyIncludes(query, includes);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        private IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
