using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.EMR.Commands;
using HealthcareSystem.Application.EMR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EMRController : ControllerBase
{
    private readonly IMediator _mediator;
    public EMRController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("patient/{id}")]
    public async Task<ActionResult<IEnumerable<MedicalRecordDto>>> GetByPatient(Guid id)
    {
        var result = await _mediator.Send(new GetEMRByPatientQuery(id));
        return Ok(result);
    }

    [HttpPost("patient/{id}/add-note")]
    public async Task<ActionResult<MedicalRecordDto>> AddNote(Guid id, [FromBody] AddEMRNoteCommand command)
    {
        if (id != command.PatientId) return BadRequest();
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
