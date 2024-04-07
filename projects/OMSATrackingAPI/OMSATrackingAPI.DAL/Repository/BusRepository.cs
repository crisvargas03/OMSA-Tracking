using Microsoft.EntityFrameworkCore;
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

        #region Obtener ruta existente
        public async Task<bool> RouteExistsAsync(Expression<Func<Route, bool>> filter)
        {
            return await _context.Set<Route>().AnyAsync(filter);
        }
        #endregion

        #region Obtener bus por id
        public async Task<Bus> GetByIdAsync(int id)
        {
            return await _context.Set<Bus>().FindAsync(id);
        }
        #endregion

        #region Eliminar
        public async Task<bool> DeleteBusAsync(int id)
        {
            var busToDelete = await _context.Set<Bus>().FindAsync(id);
            if (busToDelete != null)
            {
                busToDelete.IsDeleted = true;
                _context.Entry(busToDelete).State = EntityState.Modified;
                await SaveAsync();
                return true;
            }
            return false;
        }
        #endregion

    }
}
