using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Billing.Commands;

public class CreateBillCommand : IRequest<BillDto>
{
    public Guid PatientId { get; set; }
    public decimal Amount { get; set; }
    public string? InsuranceInfo { get; set; }
}
