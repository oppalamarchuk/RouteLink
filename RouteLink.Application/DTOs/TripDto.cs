namespace RouteLink.Application.DTOs;

public class TripDto
{
    public int Id { get; set; }
    public string TripNumber { get; set; } = string.Empty;
    public int DriverUserId { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public int TransportId { get; set; }
    public string TransportPlateNumber { get; set; } = string.Empty;
    public string StartPoint { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public decimal PlannedDistanceKm { get; set; }
    public string ExecutionStatus { get; set; } = string.Empty;
}
