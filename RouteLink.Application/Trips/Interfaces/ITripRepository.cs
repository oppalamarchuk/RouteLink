using RouteLink.Domain.Entities;
using RouteLink.Domain.Enums;

namespace RouteLink.Application.Trips.Interfaces;

public interface ITripRepository
{
    Task<List<Trip>> GetAllAsync(CancellationToken cancellationToken);
    Task<Trip?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Trip> AddAsync(Trip trip, CancellationToken cancellationToken);
    Task<Trip?> UpdateStatusAsync(int id, ExecutionStatus executionStatus, CancellationToken cancellationToken);
}
