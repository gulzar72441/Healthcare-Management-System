using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<IEnumerable<Patient>> SearchAsync(string? name, string? email, string? phone);
    Task<IEnumerable<Patient>> GetByDoctorIdAsync(Guid doctorId);
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Guid id);
}
