namespace RouteLink.Domain.Entities;

public class Transport
{
    public int Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public decimal FuelConsumptionPer100Km { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    public ICollection<FuelRefill> FuelRefills { get; set; } = new List<FuelRefill>();
}
