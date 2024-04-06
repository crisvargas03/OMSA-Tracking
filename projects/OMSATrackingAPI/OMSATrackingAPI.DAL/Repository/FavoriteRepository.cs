using OMSATrackingAPI.DAL.Data;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.Core;
using OMSATrackingAPI.DAL.Repository.IRepository;

namespace OMSATrackingAPI.DAL.Repository
{
    public class FavoriteRepository : BaseRepository<FavoriteRoute>, IFavoriteRepository
    {
        public FavoriteRepository(MainDbContext context) : base(context)
        {
        }

    }
}
