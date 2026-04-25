using AutoMapper;
using RouteLink.Application.DTOs;
using RouteLink.Domain.Entities;

namespace RouteLink.Application.Common.Mapping;

public class TripProfile : Profile
{
    public TripProfile()
    {
        CreateMap<Trip, TripDto>()
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.DriverUser.FullName))
            .ForMember(dest => dest.TransportPlateNumber, opt => opt.MapFrom(src => src.Transport.PlateNumber))
            .ForMember(dest => dest.ExecutionStatus, opt => opt.MapFrom(src => src.ExecutionStatus.ToString()));
    }
}
