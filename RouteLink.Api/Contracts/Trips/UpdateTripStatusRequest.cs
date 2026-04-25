using RouteLink.Domain.Enums;

namespace RouteLink.Api.Contracts.Trips;

public class UpdateTripStatusRequest
{
    public ExecutionStatus ExecutionStatus { get; init; }
}
