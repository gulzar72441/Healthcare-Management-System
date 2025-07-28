using HealthcareSystem.Application.DTOs;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Patients.DTOs;

public class PatientSummaryDto
{
    public Guid PatientId { get; set; }
    public IEnumerable<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    public IEnumerable<BillDto> Bills { get; set; } = new List<BillDto>();
    public IEnumerable<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
    public IEnumerable<LabOrderDto> LabOrders { get; set; } = new List<LabOrderDto>();
}
