using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Queries;

public class SearchAppointmentsQueryHandler : IRequestHandler<SearchAppointmentsQuery, IEnumerable<AppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    public SearchAppointmentsQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IEnumerable<AppointmentDto>> Handle(SearchAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.SearchAsync(request.Date, request.Status, request.DoctorId, request.PatientId);
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
