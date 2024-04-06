﻿using AutoMapper;
using OMSATrackingAPI.BLL.DTOs;
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
        private readonly IMapper _mapper;
        protected Response _response;
        public RouteService(IRouteRepository repository, IMapper mapper): base()
        {
            _repository = repository;
            _response = new();
            _mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var routes = await _repository.GetRoutesWithSubQueryAsync();
                _response.Payload = _mapper.Map<IEnumerable<RouteDto>>(routes);
                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public async Task<Response> AddRoute(Route routeRequest)
        {
            try
            {
                var routeEntity = _mapper.Map<Route>(routeRequest);
                await _repository.AddAsync(routeEntity);

                _response.Payload = _mapper.Map<RouteDto>(routeEntity);

                return _response;

            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        public async Task<Response> DeleteRoute(int routeId)
        {
            try
            {
                var routeToDelete = await _repository.GetByIdAsync(routeId);

                if (routeToDelete == null)
                {
                    return _response.FailedResponse(HttpStatusCode.NotFound, "Route not found");
                }

                await _repository.DeleteAsync(routeToDelete);

                _response.Payload = _mapper.Map<RouteDto>(routeToDelete);

                return _response;
            }
            catch (Exception ex)
            {
                return _response.FailedResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
