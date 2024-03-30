using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;

namespace OMSATrackingAPI.BLL.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _repository;
        protected Response _response;
        public BusService(IBusRepository repository)
        {
            _repository = repository;
            _response = new();
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var buses = await _repository.GetAllAsync();
                _response.Payload = buses;
                return _response;
               
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
