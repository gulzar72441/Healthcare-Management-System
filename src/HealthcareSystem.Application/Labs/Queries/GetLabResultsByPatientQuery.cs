using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Labs.Queries;

public class GetLabResultsByPatientQuery : IRequest<IEnumerable<LabOrderDto>>
{
    public Guid PatientId { get; set; }
    public GetLabResultsByPatientQuery(Guid patientId) => PatientId = patientId;
}
