using AutoMapper;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;

namespace OMSATrackingAPI.BLL.Services
{
    public class BusStopService : IBusStopService
    {
        private readonly IBusStopRepository _repository;
        private readonly IMapper _mapper;
        protected Response _response;

        public BusStopService(IBusStopRepository repository, IMapper mapper)
        {
            _repository = repository;
            _response = new();
            _mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var bus = await _repository.GetBusStopsWithRouteAsync();
                _response.Payload = _mapper.Map<IEnumerable<BusStopDto>>(bus);
                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}

