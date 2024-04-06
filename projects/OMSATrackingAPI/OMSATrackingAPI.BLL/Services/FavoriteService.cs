using AutoMapper;
using Microsoft.Extensions.Logging;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Interfaces;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;
using OMSATrackingAPI.DAL.Repository.IRepository;
using System.Net;

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

        public async Task<Response> AddFavorite(FavoriteRoute favoriteRequest)
        {
            try
            {
                var favoriteEntity = _mapper.Map<FavoriteRoute>(favoriteRequest);
                await _repository.AddAsync(favoriteEntity);

                _response.Payload = _mapper.Map<FavoriteDto>(favoriteEntity);

                return _response;

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<Response> DeleteFavorite(int favoriteId)
        {
            try
            {
                var favoriteToDelete = await _repository.GetByIdAsync(favoriteId);

                if (favoriteToDelete == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "Favorite not found");
                }

                await _repository.DeleteAsync(favoriteToDelete);

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
