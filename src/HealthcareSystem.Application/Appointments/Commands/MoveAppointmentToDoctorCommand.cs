using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class MoveAppointmentToDoctorCommand : IRequest<bool>
{
    public Guid AppointmentId { get; set; }
    public Guid NewDoctorId { get; set; }
    public MoveAppointmentToDoctorCommand(Guid appointmentId, Guid newDoctorId)
    {
        AppointmentId = appointmentId;
        NewDoctorId = newDoctorId;
    }
}
