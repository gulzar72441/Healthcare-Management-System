using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Labs.Commands;

public class CreateLabOrderCommand : IRequest<LabOrderDto>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string TestType { get; set; } = string.Empty;
}
