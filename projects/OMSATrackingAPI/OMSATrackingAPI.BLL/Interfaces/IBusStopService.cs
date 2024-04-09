using OMSATrackingAPI.BLL.Utils;
using System.Threading.Tasks;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IBusStopService
    {
        Task<Response> GetAll();
        Task<Response> GetAll(string query, int busLimit);
    }
}
