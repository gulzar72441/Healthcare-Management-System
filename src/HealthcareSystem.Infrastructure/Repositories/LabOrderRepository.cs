using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class LabOrderRepository : ILabOrderRepository
{
    private readonly HealthcareDbContext _context;
    public LabOrderRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<LabOrder?> GetByIdAsync(Guid id)
    {
        return await _context.LabOrders.FindAsync(id);
    }

    public async Task<IEnumerable<LabOrder>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.LabOrders.Where(l => l.PatientId == patientId).ToListAsync();
    }

    public async Task<IEnumerable<LabOrder>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _context.LabOrders.Where(l => l.DoctorId == doctorId).ToListAsync();
    }

    public async Task<IEnumerable<LabOrder>> SearchAsync(string? testType, DateTime? date, Guid? doctorId, Guid? patientId)
    {
        var query = _context.LabOrders.AsQueryable();
        if (!string.IsNullOrEmpty(testType))
            query = query.Where(l => l.TestType.Contains(testType));
        if (date.HasValue)
            query = query.Where(l => l.Date.Date == date.Value.Date);
        if (doctorId.HasValue)
            query = query.Where(l => l.DoctorId == doctorId);
        if (patientId.HasValue)
            query = query.Where(l => l.PatientId == patientId);
        return await query.ToListAsync();
    }

    public async Task<bool> MarkReviewedAsync(Guid labOrderId)
    {
        var labOrder = await _context.LabOrders.FindAsync(labOrderId);
        if (labOrder == null) return false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task AddAsync(LabOrder order)
    {
        await _context.LabOrders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LabOrder order)
    {
        _context.LabOrders.Update(order);
        await _context.SaveChangesAsync();
    }
}
