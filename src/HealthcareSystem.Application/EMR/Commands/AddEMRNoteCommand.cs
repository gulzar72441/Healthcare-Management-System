using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.EMR.Commands;

public class AddEMRNoteCommand : IRequest<MedicalRecordDto>
{
    public Guid PatientId { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Treatments { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    
}
