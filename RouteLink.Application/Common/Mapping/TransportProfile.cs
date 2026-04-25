using AutoMapper;
using RouteLink.Application.DTOs;
using RouteLink.Domain.Entities;

namespace RouteLink.Application.Common.Mapping;

public class TransportProfile : Profile
{
    public TransportProfile()
    {
        CreateMap<Transport, TransportDto>();
    }
}