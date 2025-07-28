namespace HealthcareSystem.Application.DTOs;

public class PrescriptionDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime Date { get; set; }
    public string Medication { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
}
