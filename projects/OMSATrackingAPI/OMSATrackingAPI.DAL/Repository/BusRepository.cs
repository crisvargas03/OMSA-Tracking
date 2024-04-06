﻿using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Linq.Expressions;

namespace OMSATrackingAPI.DAL.Repository
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        protected readonly MainDbContext _context;
        public BusRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> RouteExistsAsync(Expression<Func<Route, bool>> filter)
        {
            return await _context.Set<Route>().AnyAsync(filter);
        }

        public async Task<Bus> GetAsync(int id, bool tracked = true, params Expression<Func<Bus, object>>[] includes)
        {
            IQueryable<Bus> query = _context.Set<Bus>();

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> UpdateBusAsync(int id, Bus updatedBus)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBusAsync(int id)
        {
            var busToDelete = await _context.Set<Bus>().FindAsync(id);
            if (busToDelete != null)
            {
                busToDelete.IsDeleted = true; 
                _context.Entry(busToDelete).State = EntityState.Modified;
                return true;
            }
            return false;
        }

    }
}
