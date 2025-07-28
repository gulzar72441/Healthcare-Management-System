using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class DeleteAppointmentCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public DeleteAppointmentCommand(Guid id) => Id = id;
}
