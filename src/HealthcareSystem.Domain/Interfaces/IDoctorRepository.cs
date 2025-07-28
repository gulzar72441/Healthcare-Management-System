using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IDoctorRepository
{
    Task<IEnumerable<string>> GetSpecialtiesAsync();
    Task<Doctor?> GetByIdAsync(Guid id);
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task<IEnumerable<Doctor>> SearchAsync(string? name, string? specialty);
    Task AddAsync(Doctor doctor);
    Task UpdateAsync(Doctor doctor);
    Task DeleteAsync(Guid id);
}
