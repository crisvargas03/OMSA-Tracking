using AutoMapper;
using OMSATrackingAPI.BLL.DTOs;
using OMSATrackingAPI.DAL.Models;

namespace OMSATrackingAPI.BLL.Mappers
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<Bus, BusDto>().ReverseMap();

            CreateMap<Route, RouteDto>().ReverseMap();

            CreateMap<Driver, DriverDto>().ReverseMap();

            CreateMap<FavoriteRoute, FavoriteDto>().ReverseMap();

            CreateMap<FavoriteRoute, AddFavoriteRequest>();

        }
    }
}
