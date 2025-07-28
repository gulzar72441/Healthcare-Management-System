using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class MoveAppointmentToDoctorCommandHandler : IRequestHandler<MoveAppointmentToDoctorCommand, bool>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IDoctorRepository _doctorRepository;
    public MoveAppointmentToDoctorCommandHandler(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
    {
        _appointmentRepository = appointmentRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<bool> Handle(MoveAppointmentToDoctorCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.AppointmentId);
        var doctor = await _doctorRepository.GetByIdAsync(request.NewDoctorId);
        if (appointment == null || doctor == null) return false;
        appointment.DoctorId = doctor.Id; // Assumes Appointment has DoctorId property
        await _appointmentRepository.UpdateAsync(appointment);
        return true;
    }
}
