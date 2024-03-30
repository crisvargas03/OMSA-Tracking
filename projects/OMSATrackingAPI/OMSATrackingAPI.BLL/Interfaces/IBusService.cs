using OMSATrackingAPI.BLL.Utils;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IBusService
    {
        Task<Response> GetAll();
    }
}
