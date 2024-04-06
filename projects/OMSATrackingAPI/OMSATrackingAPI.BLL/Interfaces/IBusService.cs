using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Utils;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IBusService
    {
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        Task<Response> InsertBus(InsertBusDto busDto);
        Task<Response> UpdateBus(int id, UpdateBusDto busDto);
        Task<Response> SoftDeleteBus(int id);
    }
}
