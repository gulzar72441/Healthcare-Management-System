using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, AppointmentDto>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
        if (appointment == null)
            throw new KeyNotFoundException($"Appointment with Id {request.Id} not found.");

        appointment.PatientId = request.PatientId;
        appointment.DoctorId = request.DoctorId;
        appointment.Date = request.ScheduledAt;
        appointment.Status = request.Status;
        appointment.Reason = request.Reason;
        appointment.Notes = request.Notes;

        await _appointmentRepository.UpdateAsync(appointment);
        return _mapper.Map<AppointmentDto>(appointment);
    }
}
