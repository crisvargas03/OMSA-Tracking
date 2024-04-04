using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using System.Linq.Expressions;

namespace OMSATrackingAPI.DAL.Repository.IRepository
{
    public interface IBusRepository : IBaseRepository<Bus>
    {
        Task<bool> RouteExistsAsync(Expression<Func<Route, bool>> filter);
        Task SaveAsync();
        Task<bool> UpdateBusAsync(int id, Bus updatedBus);
        Task<bool> DeleteBusAsync(int id);
        Task<Bus> GetAsync(int id, bool tracked = true, params Expression<Func<Bus, object>>[] includes);

    }
}
