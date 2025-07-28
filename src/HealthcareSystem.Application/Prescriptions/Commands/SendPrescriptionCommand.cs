using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Prescriptions.Commands;

public class SendPrescriptionCommand : IRequest<PrescriptionDto>
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string Medication { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
}
