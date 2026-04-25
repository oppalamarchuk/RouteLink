using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Trips.Interfaces;
using RouteLink.Domain.Enums;

namespace RouteLink.Application.Trips.Commands;

public class UpdateTripStatusCommand : IRequest<TripDto?>
{
    public int Id { get; init; }
    public ExecutionStatus ExecutionStatus { get; init; }
}

public class UpdateTripStatusCommandHandler(ITripRepository repository, IMapper mapper) : IRequestHandler<UpdateTripStatusCommand, TripDto?>
{
    public async Task<TripDto?> Handle(UpdateTripStatusCommand request, CancellationToken cancellationToken)
    {
        var trip = await repository.UpdateStatusAsync(request.Id, request.ExecutionStatus, cancellationToken);
        return trip is null ? null : mapper.Map<TripDto>(trip);
    }
}
