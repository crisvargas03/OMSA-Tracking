using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;

namespace OMSATrackingAPI.DAL.Repository.IRepository
{
    public interface IRouteRepository : IBaseRepository<Route>
    {
        Task<IEnumerable<Route>> GetRoutesWithSubQueryAsync();
    }
}
