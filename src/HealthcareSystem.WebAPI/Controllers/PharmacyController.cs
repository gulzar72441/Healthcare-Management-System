using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Pharmacy.Commands;
using HealthcareSystem.Application.Pharmacy.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PharmacyController : ControllerBase
{
    private readonly IMediator _mediator;
    public PharmacyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("send-prescription")]
    public async Task<ActionResult> SendPrescription([FromBody] SendPrescriptionCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("medicine-stock/{medicineId}")]
    public async Task<ActionResult<int>> GetMedicineStock(Guid medicineId)
    {
        var result = await _mediator.Send(new GetMedicineStockQuery(medicineId));
        return Ok(result);
    }
}
