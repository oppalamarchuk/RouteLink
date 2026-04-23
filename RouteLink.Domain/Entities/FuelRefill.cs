using NetTopologySuite.Geometries;

namespace RouteLink.Domain.Entities;

public class FuelRefill
{
    public int Id { get; set; }
    public int? TripId { get; set; }
    public int DriverUserId { get; set; }
    public int TransportId { get; set; }
    public decimal Liters { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Odometer { get; set; }
    public Point Location { get; set; } = null!;
    public string ReceiptPath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Trip? Trip { get; set; }
    public User DriverUser { get; set; } = null!;
    public Transport Transport { get; set; } = null!;
    public FuelRefillValidation? Validation { get; set; }
}
