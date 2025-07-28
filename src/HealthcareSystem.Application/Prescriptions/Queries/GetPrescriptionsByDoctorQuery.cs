using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class GetPrescriptionsByDoctorQuery : IRequest<IEnumerable<PrescriptionDto>>
{
    public Guid DoctorId { get; set; }
    public GetPrescriptionsByDoctorQuery(Guid doctorId)
    {
        DoctorId = doctorId;
    }
}
