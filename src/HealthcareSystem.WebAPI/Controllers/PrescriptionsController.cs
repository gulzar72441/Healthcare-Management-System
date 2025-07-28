using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Prescriptions.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthcareSystem.Application.Prescriptions.Queries;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PrescriptionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<PrescriptionDto>> Create([FromBody] CreatePrescriptionCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetByPatient(Guid patientId)
    {
        var result = await _mediator.Send(new GetPrescriptionsByPatientQuery(patientId));
        return Ok(result);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetByDoctor(Guid doctorId)
    {
        var result = await _mediator.Send(new GetPrescriptionsByDoctorQuery(doctorId));
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<PrescriptionDto>>> Search([FromQuery] string? medication, [FromQuery] DateTime? date, [FromQuery] Guid? doctorId, [FromQuery] Guid? patientId)
    {
        var result = await _mediator.Send(new SearchPrescriptionsQuery(medication, date, doctorId, patientId));
        return Ok(result);
    }

    // Optionally, add GetById endpoint if needed in future
    [HttpGet("{id}")]
    public async Task<ActionResult<PrescriptionDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPrescriptionByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("{prescriptionId}/download")]
    public async Task<IActionResult> Download(Guid prescriptionId)
    {
        // TODO: Implement PDF generation
        // For now, return a placeholder file
        var bytes = System.Text.Encoding.UTF8.GetBytes($"Prescription PDF for {prescriptionId} (stub)");
        return File(bytes, "application/pdf", $"prescription_{prescriptionId}.pdf");
    }
}
