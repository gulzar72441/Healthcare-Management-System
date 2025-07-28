using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Appointments.Commands;

public class UpdateAppointmentCommand : IRequest<AppointmentDto>
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Status { get; set; }
    public string Reason { get; set; }
    public string? Notes { get; set; }
}
