using HealthcareSystem.Application.DTOs;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Doctors.DTOs;

public class DoctorDashboardDto
{
    public Guid DoctorId { get; set; }
    public IEnumerable<PatientDto> Patients { get; set; } = new List<PatientDto>();
    public IEnumerable<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    public IEnumerable<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
    public IEnumerable<LabOrderDto> LabOrders { get; set; } = new List<LabOrderDto>();
}
