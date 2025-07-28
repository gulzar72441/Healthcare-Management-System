using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IBillRepository
{
    Task<Bill?> GetByIdAsync(Guid id);
    Task<IEnumerable<Bill>> GetByPatientIdAsync(Guid patientId);
    Task<IEnumerable<Bill>> SearchAsync(string? status, DateTime? fromDate, DateTime? toDate, Guid? patientId, Guid? doctorId);
    Task<IEnumerable<Bill>> GetOverdueAsync();
    Task<IEnumerable<Bill>> GetPaidAsync();
    Task<IEnumerable<Bill>> GetUnpaidAsync();
    Task AddAsync(Bill bill);
    Task UpdateAsync(Bill bill);
}
