using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IPharmacyRepository
{
    Task<IEnumerable<Medicine>> GetMedicineStockAsync(Guid pharmacyId);
    Task<Pharmacy?> GetByIdAsync(Guid id);
    Task<IEnumerable<Medicine>> GetStockAsync();
    Task<Medicine?> GetMedicineByIdAsync(Guid medicineId);
    Task UpdateMedicineStockAsync(Guid medicineId, int newStock);
}
