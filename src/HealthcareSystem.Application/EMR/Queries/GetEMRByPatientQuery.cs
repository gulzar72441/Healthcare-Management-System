using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.EMR.Queries;

public class GetEMRByPatientQuery : IRequest<IEnumerable<MedicalRecordDto>>
{
    public Guid PatientId { get; set; }
    public GetEMRByPatientQuery(Guid patientId) => PatientId = patientId;
}
