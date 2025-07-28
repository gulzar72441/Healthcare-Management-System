using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Appointments.Queries;

public class GetAppointmentsByDoctorQuery : IRequest<IEnumerable<AppointmentDto>>
{
    public Guid DoctorId { get; set; }
    public GetAppointmentsByDoctorQuery(Guid doctorId)
    {
        DoctorId = doctorId;
    }
}
