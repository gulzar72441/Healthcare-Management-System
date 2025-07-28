namespace HealthcareSystem.Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime Date { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // Booked, Cancelled, Rescheduled
    public string? Notes { get; set; }
}
