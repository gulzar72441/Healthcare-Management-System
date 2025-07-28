namespace HealthcareSystem.Application.DTOs;

public class MedicineStockDto
{
    public Guid MedicineId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
