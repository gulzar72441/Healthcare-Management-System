using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Doctors.DTOs;
using HealthcareSystem.Application.Doctors.Commands;
using HealthcareSystem.Application.Doctors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;
    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDto>> Create([FromBody] CreateDoctorCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetDoctorByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DoctorDto>> Update(Guid id, [FromBody] UpdateDoctorCommand command)
    {
        if (id != command.Id) return BadRequest();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllDoctorsQuery());
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> Search([FromQuery] string? name, [FromQuery] string? specialty)
    {
        var result = await _mediator.Send(new SearchDoctorsQuery(name, specialty));
        return Ok(result);
    }

    [HttpGet("specialties")]
    public async Task<ActionResult<IEnumerable<string>>> GetSpecialties()
    {
        var result = await _mediator.Send(new GetDoctorSpecialtiesQuery());
        return Ok(result);
    }

    [HttpGet("{doctorId}/patients")]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients(Guid doctorId)
    {
        var result = await _mediator.Send(new GetPatientsByDoctorQuery(doctorId));
        return Ok(result);
    }

    [HttpGet("{doctorId}/dashboard")]
    public async Task<ActionResult<DoctorDashboardDto>> GetDashboard(Guid doctorId)
    {
        var result = await _mediator.Send(new GetDoctorDashboardQuery(doctorId));
        return Ok(result);
    }
}
