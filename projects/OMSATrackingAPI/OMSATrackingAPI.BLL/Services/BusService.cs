using AutoMapper;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;
using System.Text.Json;

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
                var buses = await _repository.GetAllAsync(tracked: false,
                    includes: [x => x.Driver]);
                _response.Payload = _mapper.Map<IEnumerable<BusDto>>(buses);
                return _response;

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                var bus = await _repository.GetAsync(x => x.Id == id);
                if (bus == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus no fue encontrado");
                }

                string busDtoJson = JsonSerializer.Serialize(bus);
                return _response.SuccessResponse(HttpStatusCode.OK, busDtoJson);

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async Task<Response> InsertBus(InsertBusDto busDto)
        {
            try
            {
                var routeExists = await _repository.RouteExistsAsync(x => x.Id == busDto.RouteId);
                if (routeExists)
                {
                    return _response.FailedResponse(HttpStatusCode.BadRequest, "La ruta especificada ya esta atada a otro bus");
                }
                else
                {
                    var bus = _mapper.Map<Bus>(busDto);
                    await _repository.AddAsync(bus);
                    await _repository.SaveAsync();
                    return _response.SuccessResponse(HttpStatusCode.Created, "Bus insertado correctamente.");
                }
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response> UpdateBus(int id, UpdateBusDto busDto)
        {
            try
            {
                var existingBus = await _repository.GetAsync(id);
                if (existingBus == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus no fue encontrado");
                }

                existingBus.Name = busDto.Name;
                existingBus.Latitude = busDto.Latitude;
                existingBus.Longitude = busDto.Longitude;
                existingBus.Plate = busDto.Plate;
                existingBus.EstimatedArrivalHour = busDto.EstimatedArrivalHour;
                existingBus.PassengerLimit = busDto.PassengerLimit;
                existingBus.RouteId = busDto.RouteId;

                // Esperar a que se complete la actualización
                if (await _repository.UpdateBusAsync(id, existingBus))
                {
                    await _repository.SaveAsync();
                    return _response.SuccessResponse(HttpStatusCode.OK, "Bus actualizado correctamente.");
                }
                else
                {
                    return _response.FailedResponse(HttpStatusCode.InternalServerError, "Error al actualizar el bus.");
                }
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response> SoftDeleteBus(int id)
        {
            try
            {
                var success = await _repository.DeleteBusAsync(id);
                if (!success)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus no fue encontrado");
                }

                return _response.SuccessResponse(HttpStatusCode.OK, "Bus eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
