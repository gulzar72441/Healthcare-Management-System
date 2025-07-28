namespace HealthcareSystem.Domain.Entities;

public class Pharmacy
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
