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
        }
    }
}
