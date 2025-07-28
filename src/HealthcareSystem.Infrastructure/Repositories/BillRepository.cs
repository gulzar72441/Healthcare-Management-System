using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class BillRepository : IBillRepository
{
    private readonly HealthcareDbContext _context;
    public BillRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<Bill?> GetByIdAsync(Guid id)
    {
        return await _context.Bills.FindAsync(id);
    }

    public async Task<IEnumerable<Bill>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.Bills.Where(b => b.PatientId == patientId).ToListAsync();
    }

    public async Task<IEnumerable<Bill>> SearchAsync(string? status, DateTime? fromDate, DateTime? toDate, Guid? patientId, Guid? doctorId)
    {
        var query = _context.Bills.AsQueryable();
        if (!string.IsNullOrEmpty(status))
            query = query.Where(b => b.Status == status);
        if (fromDate.HasValue)
            query = query.Where(b => b.DueDate >= fromDate);
        if (toDate.HasValue)
            query = query.Where(b => b.DueDate <= toDate);
        if (patientId.HasValue)
            query = query.Where(b => b.PatientId == patientId);
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Bill>> GetOverdueAsync()
    {
        return await _context.Bills.Where(b => b.Status == "Overdue").ToListAsync();
    }

    public async Task<IEnumerable<Bill>> GetPaidAsync()
    {
        return await _context.Bills.Where(b => b.Status == "Paid").ToListAsync();
    }

    public async Task<IEnumerable<Bill>> GetUnpaidAsync()
    {
        return await _context.Bills.Where(b => b.Status == "Unpaid").ToListAsync();
    }

    public async Task AddAsync(Bill bill)
    {
        await _context.Bills.AddAsync(bill);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Bill bill)
    {
        _context.Bills.Update(bill);
        await _context.SaveChangesAsync();
    }
}
