using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteLink.Domain.Entities;

namespace RouteLink.Infrastructure.Persistence.Configurations;

public class FuelRefillValidationConfiguration : IEntityTypeConfiguration<FuelRefillValidation>
{
    public void Configure(EntityTypeBuilder<FuelRefillValidation> builder)
    {
        builder.ToTable("FuelRefillValidations");

        builder.HasKey(x => x.FuelRefillId);

        builder.Property(x => x.Status).HasMaxLength(64).IsRequired();
        builder.Property(x => x.RejectionReasonCode).HasMaxLength(128);
        builder.Property(x => x.RejectionComment).HasMaxLength(1024);

        builder.HasOne(x => x.FuelRefill)
            .WithOne(x => x.Validation)
            .HasForeignKey<FuelRefillValidation>(x => x.FuelRefillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
