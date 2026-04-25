namespace RouteLink.Api.Contracts.Trips;

public class CreateTripRequest
{
    public string TripNumber { get; init; } = string.Empty;
    public int DriverUserId { get; init; }
    public int TransportId { get; init; }
    public string StartPoint { get; init; } = string.Empty;
    public string EndPoint { get; init; } = string.Empty;
    public decimal PlannedDistanceKm { get; init; }
}