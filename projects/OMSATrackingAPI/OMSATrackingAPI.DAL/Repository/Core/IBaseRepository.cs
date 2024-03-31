using System.Linq.Expressions;

namespace OMSATrackingAPI.DAL.Repository.Core
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, params Expression<Func<T, object>>[] includes);
    }
}
