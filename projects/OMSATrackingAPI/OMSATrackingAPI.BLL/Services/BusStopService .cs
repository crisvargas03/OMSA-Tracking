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

        public async Task<Response> GetAll(string query, int busLimit)
        {
            try
            {
                var busStops = await _repository.GetBusStopsWithRouteAsync(query, busLimit); // Aplicar el límite en el repositorio

                var busStopDtos = busStops.Select(bs => new BusStopDto
                {
                    Id = bs.Id.ToString(),
                    Name = bs.Name,
                    Location = new LocationDto { Latitude = double.Parse(bs.Latitude), Longitude = double.Parse(bs.Longitude) },
                    RouteId = bs.RouteId,
                    Position = bs.Position,
                    Buses = bs.Buses
                        .Select(b => new BusDto
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Latitude = b.Latitude,
                            Longitude = b.Longitude,
                            Plate = b.Plate,
                            EstimatedArrivalHour = b.EstimatedArrivalHour,
                            PassengerLimit = b.PassengerLimit,
                            RouteId = b.RouteId,
                            StopId = b.StopId
                        })
                });

                _response.Payload = busStopDtos;
                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}

