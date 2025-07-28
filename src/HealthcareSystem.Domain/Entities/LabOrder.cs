namespace HealthcareSystem.Domain.Entities;

public class LabOrder
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public string TestType { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string? Result { get; set; }
    public DateTime? ResultDate { get; set; }
}
