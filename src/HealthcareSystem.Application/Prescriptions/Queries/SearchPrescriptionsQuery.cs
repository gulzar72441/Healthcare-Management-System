using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class SearchPrescriptionsQuery : IRequest<IEnumerable<PrescriptionDto>>
{
    public string? Medication { get; set; }
    public DateTime? Date { get; set; }
    public Guid? DoctorId { get; set; }
    public Guid? PatientId { get; set; }
    public SearchPrescriptionsQuery(string? medication, DateTime? date, Guid? doctorId, Guid? patientId)
    {
        Medication = medication;
        Date = date;
        DoctorId = doctorId;
        PatientId = patientId;
    }
}
