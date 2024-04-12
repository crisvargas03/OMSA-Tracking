using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IFavoriteService
    {
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        Task<Response> Add(FavoriteBusStopDto favoriteRequest);
        Task<Response> Update(int id, FavoriteBusStopDto favoriteDto);
        Task<Response> Delete(int id);

    }
}