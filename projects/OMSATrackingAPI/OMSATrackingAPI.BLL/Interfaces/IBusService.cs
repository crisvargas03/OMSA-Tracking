using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Utils;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IBusService
    {
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        Task<Response> InsertBus(InsertBusDto busDto);
        public Task<Response> UpdateBus(int id, UpdateBusDto busDto);

    }
}
