using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteLink.Domain.Entities;

namespace RouteLink.Infrastructure.Persistence.Configurations;

public class TransportConfiguration : IEntityTypeConfiguration<Transport>
{
    public void Configure(EntityTypeBuilder<Transport> builder)
    {
        builder.ToTable("Transports");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PlateNumber).HasMaxLength(32).IsRequired();
        builder.Property(x => x.Model).HasMaxLength(128).IsRequired();
        builder.Property(x => x.FuelConsumptionPer100Km).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasIndex(x => x.PlateNumber).IsUnique();
    }
}
