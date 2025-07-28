using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.LabOrders.Commands;
using HealthcareSystem.Application.LabOrders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthcareSystem.Application.Labs.Commands;
using HealthcareSystem.Application.Labs.Queries;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabOrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public LabOrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<LabOrderDto>> Create([FromBody] CreateLabOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<LabOrderDto>>> GetByPatient(Guid patientId)
    {
        var result = await _mediator.Send(new GetLabResultsByPatientQuery(patientId));
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<LabOrderDto>>> Search([FromQuery] string? testType, [FromQuery] DateTime? date, [FromQuery] Guid? doctorId, [FromQuery] Guid? patientId)
    {
        var result = await _mediator.Send(new SearchLabOrdersQuery(testType, date, doctorId, patientId));
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LabOrderDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetLabOrderByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("{labOrderId}/result")]
    public async Task<ActionResult<string>> GetResult(Guid labOrderId)
    {
        var result = await _mediator.Send(new GetLabOrderResultQuery(labOrderId));
        return Ok(result);
    }

    [HttpPost("{labOrderId}/mark-reviewed")]
    public async Task<ActionResult> MarkReviewed(Guid labOrderId)
    {
        var success = await _mediator.Send(new MarkLabOrderReviewedCommand(labOrderId));
        if (!success) return NotFound();
        return NoContent();
    }
}
