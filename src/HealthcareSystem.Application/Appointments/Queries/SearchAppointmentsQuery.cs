using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Appointments.Queries;

public class SearchAppointmentsQuery : IRequest<IEnumerable<AppointmentDto>>
{
    public DateTime? Date { get; set; }
    public string? Status { get; set; }
    public Guid? DoctorId { get; set; }
    public Guid? PatientId { get; set; }
    public SearchAppointmentsQuery(DateTime? date, string? status, Guid? doctorId, Guid? patientId)
    {
        Date = date;
        Status = status;
        DoctorId = doctorId;
        PatientId = patientId;
    }
}
