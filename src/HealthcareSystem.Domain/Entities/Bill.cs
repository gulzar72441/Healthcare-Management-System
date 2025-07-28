namespace HealthcareSystem.Domain.Entities;

public class Bill
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = string.Empty; // e.g., "Paid", "Unpaid", "Overdue"
    public DateTime DueDate { get; set; }
    public string? InsuranceInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<BillItem> Items { get; set; } = new List<BillItem>();
}
