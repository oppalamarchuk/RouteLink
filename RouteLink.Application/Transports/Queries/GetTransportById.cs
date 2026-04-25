using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Transports.Interfaces;

namespace RouteLink.Application.Transports.Queries;

public class GetTransportByIdQuery : IRequest<TransportDto?>
{
    public int Id { get; init; }
}

public class GetTransportByIdQueryHandler(ITransportRepository repository, IMapper mapper) : IRequestHandler<GetTransportByIdQuery, TransportDto?>
{
    public async Task<TransportDto?> Handle(GetTransportByIdQuery request, CancellationToken cancellationToken)
    {
        var transport = await repository.GetByIdAsync(request.Id, cancellationToken);
        return transport is null ? null : mapper.Map<TransportDto>(transport);
    }
}
