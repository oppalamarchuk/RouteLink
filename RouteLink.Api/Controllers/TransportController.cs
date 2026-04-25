using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteLink.Api.Contracts.Transports;
using RouteLink.Application.Transports.Commands;
using RouteLink.Application.Transports.Queries;

namespace RouteLink.Api.Controllers;

[ApiController]
[Route("api/transports")]
public class TransportController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var transports = await mediator.Send(new GetTransportsQuery());
        return Ok(transports);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var transport = await mediator.Send(new GetTransportByIdQuery { Id = id });
        return transport is null ? NotFound() : Ok(transport);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransportRequest request)
    {
        var createdTransport = await mediator.Send(new CreateTransportCommand
        {
            PlateNumber = request.PlateNumber,
            Model = request.Model,
            FuelConsumptionPer100Km = request.FuelConsumptionPer100Km
        });

        return CreatedAtAction(nameof(GetById), new { id = createdTransport.Id }, createdTransport);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTransportRequest request)
    {
        var updatedTransport = await mediator.Send(new UpdateTransportCommand
        {
            Id = id,
            PlateNumber = request.PlateNumber,
            Model = request.Model,
            FuelConsumptionPer100Km = request.FuelConsumptionPer100Km
        });

        return updatedTransport is null ? NotFound() : Ok(updatedTransport);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await mediator.Send(new DeleteTransportCommand { Id = id });
        return deleted ? NoContent() : NotFound();
    }
}
