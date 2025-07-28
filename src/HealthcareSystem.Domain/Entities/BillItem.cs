namespace HealthcareSystem.Domain.Entities;

public class BillItem
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
