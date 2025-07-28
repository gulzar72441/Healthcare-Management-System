using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Appointments.Queries;

public class GetAppointmentByIdQuery : IRequest<AppointmentDto?>
{
    public Guid Id { get; set; }
    public GetAppointmentByIdQuery(Guid id) => Id = id;
}
