using HealthcareSystem.Application.Dashboard.Queries;
using HealthcareSystem.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;
    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<DashboardSummaryDto>> GetSummary()
    {
        var result = await _mediator.Send(new GetDashboardSummaryQuery());
        return Ok(result);
    }
}
