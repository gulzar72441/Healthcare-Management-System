namespace HealthcareSystem.Domain.Entities;

public class DoctorSchedule
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAvailable { get; set; }
}
