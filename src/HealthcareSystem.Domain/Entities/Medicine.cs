namespace HealthcareSystem.Domain.Entities;

public class Medicine
{
    public Guid PharmacyId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
}
