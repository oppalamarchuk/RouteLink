using Microsoft.EntityFrameworkCore;
using RouteLink.Application.Transports.Interfaces;
using RouteLink.Domain.Entities;
using RouteLink.Infrastructure.Persistence;

namespace RouteLink.Infrastructure.Repositories;

public class TransportRepository(RouteLinkDbContext context) : ITransportRepository
{
    public async Task<List<Transport>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Transports
            .AsNoTracking()
            .OrderBy(x => x.PlateNumber)
            .ToListAsync(cancellationToken);
    }

    public async Task<Transport?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Transports.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Transport> AddAsync(Transport transport, CancellationToken cancellationToken)
    {
        context.Transports.Add(transport);
        await context.SaveChangesAsync(cancellationToken);
        return transport;
    }

    public async Task DeleteAsync(Transport transport, CancellationToken cancellationToken)
    {
        context.Transports.Remove(transport);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
