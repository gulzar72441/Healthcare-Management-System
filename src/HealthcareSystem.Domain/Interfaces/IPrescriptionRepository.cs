using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IPrescriptionRepository
{
    Task<Prescription?> GetByIdAsync(Guid id);
    Task<IEnumerable<Prescription>> GetByDoctorIdAsync(Guid doctorId);
    Task<IEnumerable<Prescription>> GetByPatientIdAsync(Guid patientId);
    Task<IEnumerable<Prescription>> SearchAsync(string? medication, DateTime? date, Guid? doctorId, Guid? patientId);
    Task AddAsync(Prescription prescription);
}
