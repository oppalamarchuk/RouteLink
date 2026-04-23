namespace RouteLink.Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public string TripNumber { get; set; } = string.Empty;
    public int DriverUserId { get; set; }
    public int TransportId { get; set; }
    public int CreatedByUserId { get; set; }
    public string StartPoint { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public decimal PlannedDistanceKm { get; set; }
    public string ExecutionStatus { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public User DriverUser { get; set; } = null!;
    public User CreatedByUser { get; set; } = null!;
    public Transport Transport { get; set; } = null!;
    public ICollection<FuelRefill> FuelRefills { get; set; } = new List<FuelRefill>();
    public ICollection<TripDocument> TripDocuments { get; set; } = new List<TripDocument>();
}
