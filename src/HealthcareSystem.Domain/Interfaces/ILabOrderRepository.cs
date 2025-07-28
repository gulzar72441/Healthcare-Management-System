using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface ILabOrderRepository
{
    Task<LabOrder?> GetByIdAsync(Guid id);
    Task<IEnumerable<LabOrder>> GetByPatientIdAsync(Guid patientId);
    Task<IEnumerable<LabOrder>> GetByDoctorIdAsync(Guid doctorId);
    Task<IEnumerable<LabOrder>> SearchAsync(string? testType, DateTime? date, Guid? doctorId, Guid? patientId);
    Task<bool> MarkReviewedAsync(Guid labOrderId);
    Task AddAsync(LabOrder order);
    Task UpdateAsync(LabOrder order);
}
