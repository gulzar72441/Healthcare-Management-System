using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class PharmacyRepository : IPharmacyRepository
{
    private readonly HealthcareDbContext _context;
    public PharmacyRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicine>> GetMedicineStockAsync(Guid pharmacyId)
    {
        return await _context.Medicines.Where(m => m.PharmacyId == pharmacyId).ToListAsync();
    }

    public async Task<Pharmacy?> GetByIdAsync(Guid id)
    {
        return await _context.Pharmacies.FindAsync(id);
    }

    public async Task<IEnumerable<Medicine>> GetStockAsync()
    {
        return await _context.Medicines.ToListAsync();
    }

    public async Task<Medicine?> GetMedicineByIdAsync(Guid medicineId)
    {
        return await _context.Medicines.FindAsync(medicineId);
    }

    public async Task UpdateMedicineStockAsync(Guid medicineId, int newStock)
    {
        var medicine = await _context.Medicines.FindAsync(medicineId);
        if (medicine != null)
        {
            medicine.Stock = newStock;
            _context.Medicines.Update(medicine);
            await _context.SaveChangesAsync();
        }
    }
}
