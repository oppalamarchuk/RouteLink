namespace RouteLink.Domain.Entities;

public class TripDocument
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Trip Trip { get; set; } = null!;
    public TripDocumentValidation? Validation { get; set; }
}
