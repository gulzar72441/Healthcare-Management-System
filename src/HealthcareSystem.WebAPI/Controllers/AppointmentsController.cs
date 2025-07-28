using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Appointments.Commands;
using HealthcareSystem.Application.Appointments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> Create([FromBody] CreateAppointmentCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetByPatient(Guid patientId)
    {
        var result = await _mediator.Send(new GetAppointmentsByPatientQuery(patientId));
        return Ok(result);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetByDoctor(Guid doctorId)
    {
        var result = await _mediator.Send(new GetAppointmentsByDoctorQuery(doctorId));
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> Search([FromQuery] DateTime? date, [FromQuery] string? status, [FromQuery] Guid? doctorId, [FromQuery] Guid? patientId)
    {
        var result = await _mediator.Send(new SearchAppointmentsQuery(date, status, doctorId, patientId));
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AppointmentDto>> Update(Guid id, [FromBody] UpdateAppointmentCommand command)
    {
        if (id != command.Id) return BadRequest();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteAppointmentCommand(id));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetAppointmentByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost("{appointmentId}/move-to-doctor/{doctorId}")]
    public async Task<ActionResult> MoveToDoctor(Guid appointmentId, Guid doctorId)
    {
        await _mediator.Send(new MoveAppointmentToDoctorCommand(appointmentId, doctorId));
        return NoContent();
    }

    [HttpPost("{appointmentId}/cancel")]
    public async Task<ActionResult> Cancel(Guid appointmentId)
    {
        var success = await _mediator.Send(new CancelAppointmentCommand(appointmentId));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPost("{appointmentId}/reschedule")]
    public async Task<ActionResult> Reschedule(Guid appointmentId, [FromBody] DateTime newDate)
    {
        var success = await _mediator.Send(new RescheduleAppointmentCommand(appointmentId, newDate));
        if (!success) return NotFound();
        return NoContent();
    }
}
