using Microsoft.EntityFrameworkCore;
using RouteLink.Domain.Entities;

namespace RouteLink.Infrastructure.Persistence;

public class RouteLinkDbContext(DbContextOptions<RouteLinkDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Transport> Transports => Set<Transport>();
    public DbSet<Trip> Trips => Set<Trip>();
    public DbSet<FuelRefill> FuelRefills => Set<FuelRefill>();
    public DbSet<FuelRefillValidation> FuelRefillValidations => Set<FuelRefillValidation>();
    public DbSet<TripDocument> TripDocuments => Set<TripDocument>();
    public DbSet<TripDocumentValidation> TripDocumentValidations => Set<TripDocumentValidation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RouteLinkDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
