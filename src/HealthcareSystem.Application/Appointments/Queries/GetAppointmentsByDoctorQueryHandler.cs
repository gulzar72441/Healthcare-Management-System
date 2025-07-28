using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Queries;

public class GetAppointmentsByDoctorQueryHandler : IRequestHandler<GetAppointmentsByDoctorQuery, IEnumerable<AppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public GetAppointmentsByDoctorQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByDoctorIdAsync(request.DoctorId);
        return appointments.Select(a => new AppointmentDto
        {
            Id = a.Id,
            PatientId = a.PatientId,
            DoctorId = a.DoctorId,
            Date = a.Date,
            Reason = a.Reason,
            Status = a.Status,
            Notes = a.Notes
        });
    }
}
