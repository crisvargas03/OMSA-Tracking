using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IFavoriteService
    {
        Task<Response> GetAll();
        Task<Response> Add(FavoriteRoute favoriteRequest);
        Task<Response> Delete(int favoriteId);

    }
}