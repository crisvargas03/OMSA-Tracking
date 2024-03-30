using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;

namespace OMSATrackingAPI.BLL.Services
{
    public class RouteService : IRoutesService
    {
        private readonly IRouteRepository _repository;
        protected Response _response;
        public RouteService(IRouteRepository repository)
        {
            _repository = repository;
            _response = new();
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var routes = await _repository.GetAllAsync();
                _response.Payload = routes;
                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<Response> Insert(Route route)
        {
            try
            {
                await _repository.AddAsync(route);
                _response.Payload = route;
                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
