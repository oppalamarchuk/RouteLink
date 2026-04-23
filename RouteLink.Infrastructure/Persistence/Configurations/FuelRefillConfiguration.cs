using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteLink.Domain.Entities;

namespace RouteLink.Infrastructure.Persistence.Configurations;

public class FuelRefillConfiguration : IEntityTypeConfiguration<FuelRefill>
{
    public void Configure(EntityTypeBuilder<FuelRefill> builder)
    {
        builder.ToTable("FuelRefills");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Liters).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.TotalAmount).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.Odometer).HasPrecision(12, 2).IsRequired();
        builder.Property(x => x.Location).HasColumnType("geography").IsRequired();
        builder.Property(x => x.ReceiptPath).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.FuelRefills)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.DriverUser)
            .WithMany(x => x.FuelRefills)
            .HasForeignKey(x => x.DriverUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Transport)
            .WithMany(x => x.FuelRefills)
            .HasForeignKey(x => x.TransportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
