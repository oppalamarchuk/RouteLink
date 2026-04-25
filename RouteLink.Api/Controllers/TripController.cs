using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteLink.Api.Contracts.Trips;
using RouteLink.Application.Trips.Commands;
using RouteLink.Application.Trips.Queries;

namespace RouteLink.Api.Controllers;

[ApiController]
[Route("api/trips")]
public class TripController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trips = await mediator.Send(new GetTripsQuery());
        return Ok(trips);
    }

    [HttpGet("alerts")]
    public async Task<IActionResult> GetAlerts()
    {
        var trips = await mediator.Send(new GetTripsQuery { AlertsOnly = true });
        return Ok(trips);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTripRequest request)
    {
        var createdTrip = await mediator.Send(new CreateTripCommand
        {
            TripNumber = request.TripNumber,
            DriverUserId = request.DriverUserId,
            TransportId = request.TransportId,
            StartPoint = request.StartPoint,
            EndPoint = request.EndPoint,
            PlannedDistanceKm = request.PlannedDistanceKm
        });

        return Created($"/api/trips/{createdTrip.Id}", createdTrip);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateTripStatusRequest request)
    {
        var updatedTrip = await mediator.Send(new UpdateTripStatusCommand
        {
            Id = id,
            ExecutionStatus = request.ExecutionStatus
        });

        return updatedTrip is null ? NotFound() : Ok(updatedTrip);
    }
}
