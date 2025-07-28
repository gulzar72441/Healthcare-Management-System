using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class RescheduleAppointmentCommandHandler : IRequestHandler<RescheduleAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public RescheduleAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<bool> Handle(RescheduleAppointmentCommand request, CancellationToken cancellationToken)
    {
        return await _appointmentRepository.RescheduleAsync(request.AppointmentId, request.NewDate);
    }
}
