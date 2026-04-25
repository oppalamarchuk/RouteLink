namespace RouteLink.Api.Contracts.Transports;

public class CreateTransportRequest
{
    public string PlateNumber { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public decimal FuelConsumptionPer100Km { get; init; }
}
