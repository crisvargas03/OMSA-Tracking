using AutoMapper;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;

namespace OMSATrackingAPI.BLL.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _repository;
        private readonly IMapper _mapper;
        protected Response _response;
        public BusService(IBusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new();
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var buses = await _repository.GetAllAsync();
                _response.Payload = _mapper.Map<List<BusDto>>(buses);
                return _response;
               
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
