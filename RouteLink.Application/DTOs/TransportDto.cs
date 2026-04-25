namespace RouteLink.Application.DTOs;

public class TransportDto
{
    public int Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public decimal FuelConsumptionPer100Km { get; set; }
    public DateTime CreatedAt { get; set; }
}
