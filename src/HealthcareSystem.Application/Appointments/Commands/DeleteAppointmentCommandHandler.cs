using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
        if (appointment == null)
            return false;
        await _appointmentRepository.DeleteAsync(appointment.Id);
        return true;
    }
}
