using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RouteLink.Application.Transports.Interfaces;
using RouteLink.Application.Trips.Interfaces;
using RouteLink.Infrastructure.Persistence;
using RouteLink.Infrastructure.Repositories;

namespace RouteLink.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        services.AddDbContext<RouteLinkDbContext>(options =>
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.UseNetTopologySuite();
                optionsBuilder.MigrationsAssembly(typeof(RouteLinkDbContext).Assembly.FullName);
            }));
        
        services.AddScoped<ITransportRepository, TransportRepository>();
        services.AddScoped<ITripRepository, TripRepository>();
        
        return services;
    }
}
