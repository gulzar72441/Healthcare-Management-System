using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Commands;

public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            Date = request.ScheduledAt,
            Notes = request.Notes,
            Reason = request.Reason,
            Status = "Booked"
        };
        await _appointmentRepository.AddAsync(appointment);
        return _mapper.Map<AppointmentDto>(appointment);
    }
}
