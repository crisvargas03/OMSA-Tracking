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

            CreateMap<InsertBusDto, Bus>().ReverseMap();

            CreateMap<UpdateBusDto, Bus>().ReverseMap();

            CreateMap<Route, RouteDto>().ReverseMap();

            CreateMap<Driver, DriverDto>().ReverseMap();

            CreateMap<BusStop, BusStopDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new LocationDto { Latitude = double.Parse(src.Latitude), Longitude = double.Parse(src.Longitude) }))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(src => src.RouteId))
                .ReverseMap();

        }
    }
}
