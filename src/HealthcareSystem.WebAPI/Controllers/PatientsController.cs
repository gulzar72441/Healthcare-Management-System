using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Patients.Commands;
using HealthcareSystem.Application.Patients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthcareSystem.Application.Patients.DTOs;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<PatientDto>> Create([FromBody] CreatePatientCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPatientByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PatientDto>> Update(Guid id, [FromBody] UpdatePatientCommand command)
    {
        if (id != command.Id) return BadRequest();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeletePatientCommand(id));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllPatientsQuery());
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<PatientDto>>> Search([FromQuery] string? name, [FromQuery] string? email, [FromQuery] string? phone)
    {
        var result = await _mediator.Send(new SearchPatientsQuery(name, email, phone));
        return Ok(result);
    }

    [HttpGet("{patientId}/summary")]
    public async Task<ActionResult<PatientSummaryDto>> GetSummary(Guid patientId)
    {
        var result = await _mediator.Send(new GetPatientSummaryQuery(patientId));
        return Ok(result);
    }

    [HttpPost("{patientId}/move-to-doctor/{doctorId}")]
    public async Task<ActionResult> MoveToDoctor(Guid patientId, Guid doctorId)
    {
        var result = await _mediator.Send(new MovePatientToDoctorCommand(patientId, doctorId));
        if (!result) return NotFound();
        return NoContent();
    }
}
