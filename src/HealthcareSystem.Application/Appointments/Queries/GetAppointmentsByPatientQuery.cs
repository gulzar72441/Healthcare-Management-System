using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Appointments.Queries;

public class GetAppointmentsByPatientQuery : IRequest<IEnumerable<AppointmentDto>>
{
    public Guid PatientId { get; set; }
    public GetAppointmentsByPatientQuery(Guid patientId) => PatientId = patientId;
}
