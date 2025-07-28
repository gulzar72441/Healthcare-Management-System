using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetPatientsByDoctorQuery : IRequest<IEnumerable<PatientDto>>
{
    public Guid DoctorId { get; set; }
    public GetPatientsByDoctorQuery(Guid doctorId)
    {
        DoctorId = doctorId;
    }
}
