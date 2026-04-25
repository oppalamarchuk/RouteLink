using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Transports.Interfaces;
using RouteLink.Domain.Entities;

namespace RouteLink.Application.Transports.Commands;

public class CreateTransportCommand : IRequest<TransportDto>
{
    public string PlateNumber { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public decimal FuelConsumptionPer100Km { get; init; }
}

public class CreateTransportCommandHandler(ITransportRepository repository, IMapper mapper) : IRequestHandler<CreateTransportCommand, TransportDto>
{
    public async Task<TransportDto> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
    {
        var transport = new Transport
        {
            PlateNumber = request.PlateNumber.Trim(),
            Model = request.Model.Trim(),
            FuelConsumptionPer100Km = request.FuelConsumptionPer100Km,
            CreatedAt = DateTime.UtcNow
        };

        var createdTransport = await repository.AddAsync(transport, cancellationToken);
        return mapper.Map<TransportDto>(createdTransport);
    }
}
