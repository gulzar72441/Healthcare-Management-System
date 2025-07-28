using System.Threading.Tasks;
using System.Collections.Generic;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Domain.Interfaces;

public interface IAppointmentRepository
{
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId);
    Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId);
    Task<IEnumerable<Appointment>> SearchAsync(DateTime? date, string? status, Guid? doctorId, Guid? patientId);
    Task<bool> CancelAsync(Guid appointmentId);
    Task<bool> RescheduleAsync(Guid appointmentId, DateTime newDate);
}
