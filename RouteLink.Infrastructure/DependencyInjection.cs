using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RouteLink.Infrastructure.Persistence;

namespace RouteLink.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {      
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));
        
        services.AddDbContext<RouteLinkDbContext>(options =>
            options.UseNpgsql(connectionString,optionsBuilder =>
            {
                optionsBuilder.MigrationsAssembly(typeof(RouteLinkDbContext).Assembly.FullName);
            }));
        
        return services;
    }
}
