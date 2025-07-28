namespace HealthcareSystem.Application.DTOs;

public class BillDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public string? InsuranceInfo { get; set; }
    public DateTime CreatedAt { get; set; }
}
