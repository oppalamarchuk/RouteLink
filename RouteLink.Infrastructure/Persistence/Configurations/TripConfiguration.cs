using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteLink.Domain.Entities;

namespace RouteLink.Infrastructure.Persistence.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable("Trips");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TripNumber).HasMaxLength(64).IsRequired();
        builder.Property(x => x.StartPoint).HasMaxLength(256).IsRequired();
        builder.Property(x => x.EndPoint).HasMaxLength(256).IsRequired();
        builder.Property(x => x.PlannedDistanceKm).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.ExecutionStatus).HasMaxLength(64).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasIndex(x => x.TripNumber).IsUnique();

        builder.HasOne(x => x.DriverUser)
            .WithMany(x => x.DriverTrips)
            .HasForeignKey(x => x.DriverUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CreatedByUser)
            .WithMany(x => x.CreatedTrips)
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Transport)
            .WithMany(x => x.Trips)
            .HasForeignKey(x => x.TransportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
