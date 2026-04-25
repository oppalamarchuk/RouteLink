using RouteLink.Domain.Entities;

namespace RouteLink.Application.Transports.Interfaces;

public interface ITransportRepository
{
    Task<List<Transport>> GetAllAsync(CancellationToken cancellationToken);
    Task<Transport?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Transport> AddAsync(Transport transport, CancellationToken cancellationToken);
    Task DeleteAsync(Transport transport, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
