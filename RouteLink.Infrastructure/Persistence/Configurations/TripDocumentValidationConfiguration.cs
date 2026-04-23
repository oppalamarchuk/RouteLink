using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteLink.Domain.Entities;

namespace RouteLink.Infrastructure.Persistence.Configurations;

public class TripDocumentValidationConfiguration : IEntityTypeConfiguration<TripDocumentValidation>
{
    public void Configure(EntityTypeBuilder<TripDocumentValidation> builder)
    {
        builder.ToTable("TripDocumentValidations");

        builder.HasKey(x => x.TripDocumentId);

        builder.Property(x => x.Status).HasMaxLength(64).IsRequired();
        builder.Property(x => x.RejectionReasonCode).HasMaxLength(128);
        builder.Property(x => x.RejectionComment).HasMaxLength(1024);
        builder.Property(x => x.UpdatedAt).IsRequired();

        builder.HasOne(x => x.TripDocument)
            .WithOne(x => x.Validation)
            .HasForeignKey<TripDocumentValidation>(x => x.TripDocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
