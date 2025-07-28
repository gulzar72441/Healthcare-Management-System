using MediatR;
using System;

namespace HealthcareSystem.Application.Appointments.Commands;

public class RescheduleAppointmentCommand : IRequest<bool>
{
    public Guid AppointmentId { get; set; }
    public DateTime NewDate { get; set; }
    public RescheduleAppointmentCommand(Guid appointmentId, DateTime newDate)
    {
        AppointmentId = appointmentId;
        NewDate = newDate;
    }
}
