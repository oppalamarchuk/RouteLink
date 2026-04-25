using AutoMapper;
using MediatR;
using RouteLink.Application.DTOs;
using RouteLink.Application.Trips.Interfaces;
using RouteLink.Domain.Enums;

namespace RouteLink.Application.Trips.Queries;

public class GetTripsQuery : IRequest<List<TripDto>>
{
    public bool AlertsOnly { get; init; }
}

public class GetTripsQueryHandler(ITripRepository repository, IMapper mapper) : IRequestHandler<GetTripsQuery, List<TripDto>>
{
    public async Task<List<TripDto>> Handle(GetTripsQuery request, CancellationToken cancellationToken)
    {
        var trips = await repository.GetAllAsync(cancellationToken);
        
        if (request.AlertsOnly)
        {
            trips = trips
                .Where(trip => trip.ExecutionStatus == ExecutionStatus.Waiting)
                .ToList();
        }

        return mapper.Map<List<TripDto>>(trips.OrderByDescending(trip => trip.CreatedAt).ToList());
    }
}
