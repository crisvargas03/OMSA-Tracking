using AutoMapper;
using Microsoft.Extensions.Logging;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;
using System.Text.Json;

namespace OMSATrackingAPI.BLL.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repository;
        private readonly IMapper _mapper;
        protected Response _response;
        public FavoriteService(IFavoriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _response = new();
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var favorites = await _repository.GetFavoriteBusStopsWithRouteAsync();
                _response.Payload = _mapper.Map<IEnumerable<FavoriteBusStop>>(favorites);
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
                var favorite = await _repository.GetByIdAsync(id);

                if (favorite == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "La Parada Favorita no fue encontrada");
                }

                _response.Payload = _mapper.Map<FavoriteBusStopDto>(favorite);

                return _response;


            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public async Task<Response> Add(FavoriteBusStopDto favoriteRequest)
        {
            try
            {
                var favorite = _mapper.Map<FavoriteBusStop>(favoriteRequest);
                await _repository.AddAsync(favorite);
                return _response.SuccessResponse(HttpStatusCode.Created, "Parada Favorita insertada correctamente.");
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        public async Task<Response> Update(int id, FavoriteBusStopDto FavoriteRouteDto)
        {
            try
            {
                var existingFavoriteBusStop = await _repository.GetAsync(x => x.Id == id);

                if (existingFavoriteBusStop == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "Para Favorita  no fue encontrado");
                }

                _mapper.Map(FavoriteRouteDto, existingFavoriteBusStop);

                if (await _repository.UpdateAsync(existingFavoriteBusStop))
                {
                    return _response.SuccessResponse(HttpStatusCode.OK, "Para Favorita actualizado correctamente.");
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

        public async Task<Response> Delete(int id)
        {
            try
            {
                var favoriteToDelete = await _repository.GetByIdAsync(id);

                if (favoriteToDelete == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "La parada favorita no fue encontrada");
                }

                favoriteToDelete.IsDeleted = true;
                favoriteToDelete.ModificationDate = DateTime.UtcNow;

                await _repository.UpdateAsync(favoriteToDelete);

                _response.Payload = _mapper.Map<FavoriteBusStopDto>(favoriteToDelete);

                return _response;

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




    }
}
