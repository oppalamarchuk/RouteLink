namespace RouteLink.Domain.Entities;

public class FuelRefillValidation
{
    public int FuelRefillId { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool IsConsumptionMismatch { get; set; }
    public string? RejectionReasonCode { get; set; }
    public string? RejectionComment { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public FuelRefill FuelRefill { get; set; } = null!;
}
