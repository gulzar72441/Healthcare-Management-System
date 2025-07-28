namespace HealthcareSystem.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Type { get; set; } = string.Empty; // Email, SMS
    public string Status { get; set; } = string.Empty; // e.g., Pending, Sent, Failed
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
