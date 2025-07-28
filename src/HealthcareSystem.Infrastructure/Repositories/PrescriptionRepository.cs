using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly HealthcareDbContext _context;
    public PrescriptionRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<Prescription?> GetByIdAsync(Guid id)
    {
        return await _context.Prescriptions.FindAsync(id);
    }

    public async Task<IEnumerable<Prescription>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _context.Prescriptions.Where(p => p.DoctorId == doctorId).ToListAsync();
    }

    public async Task<IEnumerable<Prescription>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.Prescriptions.Where(p => p.PatientId == patientId).ToListAsync();
    }

    public async Task<IEnumerable<Prescription>> SearchAsync(string? medication, DateTime? date, Guid? doctorId, Guid? patientId)
    {
        var query = _context.Prescriptions.AsQueryable();
        if (!string.IsNullOrEmpty(medication))
            query = query.Where(p => p.Medication.Contains(medication));
        if (date.HasValue)
            query = query.Where(p => p.Date.Date == date.Value.Date);
        if (doctorId.HasValue)
            query = query.Where(p => p.DoctorId == doctorId);
        if (patientId.HasValue)
            query = query.Where(p => p.PatientId == patientId);
        return await query.ToListAsync();
    }

    public async Task AddAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }
}
