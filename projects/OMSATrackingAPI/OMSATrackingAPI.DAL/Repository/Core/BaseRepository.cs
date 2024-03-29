using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Data;
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

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
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
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
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
            return await query.FirstOrDefaultAsync();
        }
    }
}
