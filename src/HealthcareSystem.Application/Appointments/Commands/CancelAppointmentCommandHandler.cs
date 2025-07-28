using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
    {
        return await _appointmentRepository.CancelAsync(request.AppointmentId);
    }
}
