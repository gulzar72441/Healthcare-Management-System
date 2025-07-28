using MediatR;
using System;

namespace HealthcareSystem.Application.Appointments.Commands;

public class CancelAppointmentCommand : IRequest<bool>
{
    public Guid AppointmentId { get; set; }
    public CancelAppointmentCommand(Guid appointmentId) => AppointmentId = appointmentId;
}
