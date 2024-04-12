using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Models;


namespace OMSATrackingAPI.DAL.Repository.IRepository
{
    public interface IFavoriteRepository : IBaseRepository<FavoriteBusStop>
    {
        Task<IEnumerable<FavoriteBusStop>> GetFavoriteBusStopsWithRouteAsync();
        Task SaveAsync();

    }
}
