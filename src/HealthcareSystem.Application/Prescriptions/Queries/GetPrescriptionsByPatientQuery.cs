using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class GetPrescriptionsByPatientQuery : IRequest<IEnumerable<PrescriptionDto>>
{
    public Guid PatientId { get; set; }
    public GetPrescriptionsByPatientQuery(Guid patientId) => PatientId = patientId;
}
