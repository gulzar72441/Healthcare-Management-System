using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly HealthcareDbContext _context;
    public PatientRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
        => await _context.Patients.ToListAsync();

    public async Task<Patient?> GetByIdAsync(Guid id)
        => await _context.Patients.FindAsync(id);

    public async Task<IEnumerable<Patient>> SearchAsync(string? name, string? email, string? phone)
    {
        var query = _context.Patients.AsQueryable();
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name));
        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(p => p.Email.Contains(email));
        if (!string.IsNullOrWhiteSpace(phone))
            query = query.Where(p => p.Phone.Contains(phone));
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Patient>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _context.Patients.Where(p => p.DoctorId == doctorId).ToListAsync();
    }

    public async Task AddAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
