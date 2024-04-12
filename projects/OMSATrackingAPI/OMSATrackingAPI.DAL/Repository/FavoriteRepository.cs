using Microsoft.EntityFrameworkCore;
using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Repository.IRepository;

namespace OMSATrackingAPI.DAL.Repository
{
    public class FavoriteRepository : BaseRepository<FavoriteBusStop>, IFavoriteRepository
    {
        protected readonly MainDbContext _context;

        public FavoriteRepository(MainDbContext context) : base(context)
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
        public async Task<IEnumerable<FavoriteBusStop>> GetFavoriteBusStopsWithRouteAsync()
        {
            var favoriteBusStop = await _context.FavoriteBusStop
                .AsNoTracking()
                .Include(bs => bs.BusStop)
                .ToListAsync();

            return favoriteBusStop;

        }

    }
}
