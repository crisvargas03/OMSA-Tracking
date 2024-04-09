using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMSATrackingAPI.DAL.Repository
{
    public class BusStopRepository : BaseRepository<BusStop>, IBusStopRepository
    {
        protected readonly MainDbContext _context;
        public BusStopRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BusStop>> GetBusStopsWithRouteAsync()
        {
            return await _context.BusStop
                .Include(bs => bs.Route)
                .Include(bs => bs.Buses)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusStop>> GetBusStopsWithRouteAsync(string query, int busLimit)
        {
            return await _context.BusStop
                .Include(bs => bs.Route)
                .Include(bs => bs.Buses)
                .Where(bs => bs.Name.Contains(query))
                .Take(busLimit)
                .ToListAsync();
        }

    }
}
