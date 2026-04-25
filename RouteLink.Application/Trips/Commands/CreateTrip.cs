using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Trips.Interfaces;
using RouteLink.Domain.Entities;
using RouteLink.Domain.Enums;

namespace RouteLink.Application.Trips.Commands;

public class CreateTripCommand : IRequest<TripDto>
{
    public string TripNumber { get; init; } = string.Empty;
    public int DriverUserId { get; init; }
    public int TransportId { get; init; }
    public string StartPoint { get; init; } = string.Empty;
    public string EndPoint { get; init; } = string.Empty;
    public decimal PlannedDistanceKm { get; init; }
}

public class CreateTripCommandHandler(ITripRepository repository, IMapper mapper) : IRequestHandler<CreateTripCommand, TripDto>
{
    public async Task<TripDto> Handle(CreateTripCommand request, CancellationToken cancellationToken)
    {
        var utcNow = DateTime.UtcNow;
        var trip = new Trip
        {
            TripNumber = request.TripNumber.Trim(),
            DriverUserId = request.DriverUserId,
            TransportId = request.TransportId,
            StartPoint = request.StartPoint.Trim(),
            EndPoint = request.EndPoint.Trim(),
            PlannedDistanceKm = request.PlannedDistanceKm,
            ExecutionStatus = ExecutionStatus.Scheduled,
            CreatedAt = utcNow
        };

        var createdTrip = await repository.AddAsync(trip, cancellationToken);
        return mapper.Map<TripDto>(createdTrip);
    }
}
