using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Transports.Interfaces;

namespace RouteLink.Application.Transports.Queries;

public class GetTransportsQuery : IRequest<List<TransportDto>>;

public class GetAllTransportQueryHandler(ITransportRepository repository, IMapper mapper) : IRequestHandler<GetTransportsQuery, List<TransportDto>>
{
    public async Task<List<TransportDto>> Handle(GetTransportsQuery request, CancellationToken cancellationToken)
    {
        var transports = await repository.GetAllAsync(cancellationToken);
        return mapper.Map<List<TransportDto>>(transports);
    }
}
