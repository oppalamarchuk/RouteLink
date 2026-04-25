using MediatR;
using RouteLink.Application.Transports.Interfaces;

namespace RouteLink.Application.Transports.Commands;

public class DeleteTransportCommand : IRequest<bool>
{
    public int Id { get; init; }
}

public class DeleteTransportCommandHandler(ITransportRepository repository) : IRequestHandler<DeleteTransportCommand, bool>
{
    public async Task<bool> Handle(DeleteTransportCommand request, CancellationToken cancellationToken)
    {
        var transport = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (transport is null)
        {
            return false;
        }

        await repository.DeleteAsync(transport, cancellationToken);
        return true;
    }
}
