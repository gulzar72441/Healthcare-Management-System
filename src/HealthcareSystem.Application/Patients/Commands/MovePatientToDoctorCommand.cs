using MediatR;

namespace HealthcareSystem.Application.Patients.Commands;

public class MovePatientToDoctorCommand : IRequest<bool>
{
    public Guid PatientId { get; set; }
    public Guid NewDoctorId { get; set; }
    public MovePatientToDoctorCommand(Guid patientId, Guid newDoctorId)
    {
        PatientId = patientId;
        NewDoctorId = newDoctorId;
    }
}
