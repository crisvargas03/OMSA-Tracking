﻿using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.BLL.Utils;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.BLL.Interfaces
{
    public interface IRoutesService
    {
        Task<Response> GetAll();
        Task<Response> AddRoute(Route routeRequest);
        Task<Response> DeleteRoute(int routeId);
    }
}
