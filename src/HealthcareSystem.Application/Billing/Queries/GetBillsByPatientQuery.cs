using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetBillsByPatientQuery : IRequest<IEnumerable<BillDto>>
{
    public Guid PatientId { get; set; }
    public GetBillsByPatientQuery(Guid patientId) => PatientId = patientId;
}
