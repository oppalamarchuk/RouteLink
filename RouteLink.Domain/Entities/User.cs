namespace RouteLink.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<Trip> DriverTrips { get; set; } = new List<Trip>();
    public ICollection<FuelRefill> FuelRefills { get; set; } = new List<FuelRefill>();
}
