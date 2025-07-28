using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Billing.Queries;

public class SearchBillsQuery : IRequest<IEnumerable<BillDto>>
{
    public string? Status { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public Guid? PatientId { get; set; }
    public Guid? DoctorId { get; set; }
    public SearchBillsQuery(string? status, DateTime? fromDate, DateTime? toDate, Guid? patientId, Guid? doctorId)
    {
        Status = status;
        FromDate = fromDate;
        ToDate = toDate;
        PatientId = patientId;
        DoctorId = doctorId;
    }
}
