using HealthcareSystem.Application.Patients.DTOs;
using MediatR;
using System;

namespace HealthcareSystem.Application.Patients.Queries;

public class GetPatientSummaryQuery : IRequest<PatientSummaryDto>
{
    public Guid PatientId { get; set; }
    public GetPatientSummaryQuery(Guid patientId) => PatientId = patientId;
}
