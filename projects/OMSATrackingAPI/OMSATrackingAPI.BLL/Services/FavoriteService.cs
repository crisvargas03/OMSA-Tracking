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
                var favorites = await _repository.GetAllAsync(tracked: false,
                    includes: [x => x.Bus]);
                _response.Payload = _mapper.Map<IEnumerable<FavoriteDto>>(favorites);
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
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus favorito no fue encontrado");
                }

                _response.Payload = _mapper.Map<FavoriteDto>(favorite);

                return _response;


            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<Response> Add(FavoriteRoute favoriteRequest)
        {
            try
            {
                var favoriteEntity = _mapper.Map<FavoriteRoute>(favoriteRequest);
                
                var favorite = await _repository.GetByIdAsync(favoriteEntity.Id);

                if (favorite is not null && favorite.IsDeleted)
                {
                    await _repository.AddAsync(favorite);
                    favorite.IsDeleted = false;
                }
                else
                {
                    await _repository.AddAsync(favoriteEntity);
                }

                _response.Payload = _mapper.Map<FavoriteDto>(favoriteEntity);

                return _response;

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<Response> Update(int id, FavoriteRoute FavoriteRouteDto)
        {
            try
            {
                var existingFavorite = await _repository.GetByIdAsync(id);

                if (existingFavorite == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus favorito no fue encontrado");
                }

                existingFavorite.UserIdentificationCode = FavoriteRouteDto.UserIdentificationCode;
                existingFavorite.IdBus = FavoriteRouteDto.IdBus;
                existingFavorite.ModificationDate = DateTime.UtcNow;

                await _repository.UpdateAsync(existingFavorite);

                _response.Payload = _mapper.Map<FavoriteDto>(existingFavorite);

                return _response;

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
                    return _response.FailedResponse(HttpStatusCode.NotFound, "El bus favorito no fue encontrado");
                }

                favoriteToDelete.IsDeleted = true;
                favoriteToDelete.ModificationDate = DateTime.UtcNow;

                await _repository.UpdateAsync(favoriteToDelete);

                _response.Payload = _mapper.Map<FavoriteDto>(favoriteToDelete);

                return _response;

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




    }
}
