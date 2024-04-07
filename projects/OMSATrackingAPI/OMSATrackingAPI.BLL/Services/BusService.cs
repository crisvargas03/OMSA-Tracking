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

        #region Obtener todos los buses
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
        #endregion

        #region Obtener bus por id
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
        #endregion

        #region Insertar bus
        public async Task<Response> InsertBus(InsertBusDto busDto)
        {
            try
            {       var bus = _mapper.Map<Bus>(busDto);
                    await _repository.AddAsync(bus);
                    return _response.SuccessResponse(HttpStatusCode.Created, "Bus insertado correctamente.");
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Actualizar bus por id
        public async Task<Response> UpdateBus(int id, UpdateBusDto busDto)
        {
            try
            {
                var existingBus = await _repository.GetAsync(x => x.Id == id);

                if (existingBus == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus no fue encontrado");
                }

                _mapper.Map(busDto, existingBus);

                if (await _repository.UpdateAsync(existingBus))
                {
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
        #endregion

        #region Eliminar bus
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
        #endregion

    }
}
