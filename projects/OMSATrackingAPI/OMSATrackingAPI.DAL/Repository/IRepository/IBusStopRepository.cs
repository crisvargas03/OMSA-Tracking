using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMSATrackingAPI.DAL.Repository.IRepository
{
    public interface IBusStopRepository : IBaseRepository<BusStop>
    {
        Task<IEnumerable<BusStop>> GetBusStopsWithRouteAsync();
    }
}
