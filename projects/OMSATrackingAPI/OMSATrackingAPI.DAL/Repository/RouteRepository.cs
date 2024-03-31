using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Repository.IRepository;

namespace OMSATrackingAPI.DAL.Repository
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        private readonly MainDbContext _context;
        public RouteRepository(MainDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Route>> GetRoutesWithSubQueryAsync()
        {
           var routes = await _context.Route
                .AsNoTracking()
                .Include(x => x.Buses)
                .ThenInclude(x => x.Driver)
                .ToListAsync();
            
            return routes;
        }
    }
}
