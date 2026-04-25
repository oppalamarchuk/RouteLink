using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Transports.Interfaces;

namespace RouteLink.Application.Transports.Commands;

public class UpdateTransportCommand : IRequest<TransportDto?>
{
    public int Id { get; init; }
    public string PlateNumber { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public decimal FuelConsumptionPer100Km { get; init; }
}

public class UpdateTransportCommandHandler(ITransportRepository repository, IMapper mapper) : IRequestHandler<UpdateTransportCommand, TransportDto?>
{
    public async Task<TransportDto?> Handle(UpdateTransportCommand request, CancellationToken cancellationToken)
    {
        var transport = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (transport is null)
        {
            return null;
        }

        transport.PlateNumber = request.PlateNumber.Trim();
        transport.Model = request.Model.Trim();
        transport.FuelConsumptionPer100Km = request.FuelConsumptionPer100Km;

        await repository.SaveChangesAsync(cancellationToken);

        return mapper.Map<TransportDto>(transport);
    }
}
