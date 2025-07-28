using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly HealthcareDbContext _context;
    public DoctorRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _context.Doctors.ToListAsync();
    }

    public async Task<IEnumerable<Doctor>> SearchAsync(string? name, string? specialty)
    {
        var query = _context.Doctors.AsQueryable();
        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(d => d.FirstName.Contains(name) || d.LastName.Contains(name));
        if (!string.IsNullOrWhiteSpace(specialty))
            query = query.Where(d => d.Specialty.Contains(specialty));
        return await query.ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(Guid id)
    {
        return await _context.Doctors.FindAsync(id);
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<string>> GetSpecialtiesAsync()
    {
        return await _context.Doctors
            .Select(d => d.Specialty)
            .Distinct()
            .ToListAsync();
    }
}
