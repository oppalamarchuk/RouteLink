namespace RouteLink.Domain.Entities;

public class TripDocumentValidation
{
    public int TripDocumentId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? RejectionReasonCode { get; set; }
    public string? RejectionComment { get; set; }
    public DateTime UpdatedAt { get; set; }

    public TripDocument TripDocument { get; set; } = null!;
}
