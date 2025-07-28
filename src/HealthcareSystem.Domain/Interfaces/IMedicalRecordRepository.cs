using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IMedicalRecordRepository
{
    Task<MedicalRecord?> GetByIdAsync(Guid id);
    Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(Guid patientId);
    Task AddAsync(MedicalRecord record);
    Task UpdateAsync(MedicalRecord record);
}
