using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Billing.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthcareSystem.Application.Billing.Queries;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingController : ControllerBase
{
    private readonly IMediator _mediator;
    public BillingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<BillDto>> Create([FromBody] CreateBillCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPost("{id}/pay")]
    public async Task<ActionResult<BillDto>> Pay(Guid id, [FromBody] PayBillCommand command)
    {
        if (id != command.BillId) return BadRequest();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<BillDto>>> GetByPatient(Guid patientId)
    {
        var result = await _mediator.Send(new GetBillsByPatientQuery(patientId));
        return Ok(result);
    }

    [HttpGet("unpaid")]
    public async Task<ActionResult<IEnumerable<BillDto>>> GetUnpaid()
    {
        var result = await _mediator.Send(new GetUnpaidBillsQuery());
        return Ok(result);
    }

    [HttpGet("paid")]
    public async Task<ActionResult<IEnumerable<BillDto>>> GetPaid()
    {
        var result = await _mediator.Send(new GetPaidBillsQuery());
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<BillDto>>> Search([FromQuery] string? status, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] Guid? patientId, [FromQuery] Guid? doctorId)
    {
        var result = await _mediator.Send(new SearchBillsQuery(status, fromDate, toDate, patientId, doctorId));
        return Ok(result);
    }

    [HttpGet("overdue")]
    public async Task<ActionResult<IEnumerable<BillDto>>> GetOverdue()
    {
        var result = await _mediator.Send(new GetOverdueBillsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BillDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBillByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }
}
