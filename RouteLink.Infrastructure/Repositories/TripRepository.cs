using Microsoft.EntityFrameworkCore;
using RouteLink.Application.Trips.Interfaces;
using RouteLink.Domain.Entities;
using RouteLink.Domain.Enums;
using RouteLink.Infrastructure.Persistence;

namespace RouteLink.Infrastructure.Repositories;

public class TripRepository(RouteLinkDbContext context) : ITripRepository
{
    public async Task<List<Trip>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Trips
            .AsNoTracking()
            .Include(x => x.DriverUser)
            .Include(x => x.Transport)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Trip?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Trips
            .Include(x => x.DriverUser)
            .Include(x => x.Transport)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<Trip> AddAsync(Trip trip, CancellationToken cancellationToken)
    {
        context.Trips.Add(trip);
        await context.SaveChangesAsync(cancellationToken);

        return await GetByIdAsync(trip.Id, cancellationToken)
            ?? throw new InvalidOperationException("Failed to reload the created trip.");
    }

    public async Task<Trip?> UpdateStatusAsync(int id, ExecutionStatus executionStatus, CancellationToken cancellationToken)
    {
        var trip = await context.Trips
            .Include(x => x.DriverUser)
            .Include(x => x.Transport)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (trip is null)
        {
            return null;
        }

        trip.ExecutionStatus = executionStatus;
        await context.SaveChangesAsync(cancellationToken);
        return trip;
    }
}
