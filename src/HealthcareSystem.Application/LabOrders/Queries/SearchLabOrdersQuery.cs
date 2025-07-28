using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.LabOrders.Queries;

public class SearchLabOrdersQuery : IRequest<IEnumerable<LabOrderDto>>
{
    public string? TestType { get; set; }
    public DateTime? Date { get; set; }
    public Guid? DoctorId { get; set; }
    public Guid? PatientId { get; set; }
    public SearchLabOrdersQuery(string? testType, DateTime? date, Guid? doctorId, Guid? patientId)
    {
        TestType = testType;
        Date = date;
        DoctorId = doctorId;
        PatientId = patientId;
    }
}
