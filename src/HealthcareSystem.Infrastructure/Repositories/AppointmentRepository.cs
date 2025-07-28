using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly HealthcareDbContext _context;
    public AppointmentRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments.ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId)
    {
        return await _context.Appointments.Where(a => a.DoctorId == doctorId).ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> SearchAsync(DateTime? date, string? status, Guid? doctorId, Guid? patientId)
    {
        var query = _context.Appointments.AsQueryable();
        if (date.HasValue)
            query = query.Where(a => a.Date.Date == date.Value.Date);
        if (!string.IsNullOrEmpty(status))
            query = query.Where(a => a.Status == status);
        if (doctorId.HasValue)
            query = query.Where(a => a.DoctorId == doctorId);
        if (patientId.HasValue)
            query = query.Where(a => a.PatientId == patientId);
        return await query.ToListAsync();
    }

    public async Task<bool> CancelAsync(Guid appointmentId)
    {
        var appointment = await _context.Appointments.FindAsync(appointmentId);
        if (appointment == null) return false;
        appointment.Status = "Cancelled";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RescheduleAsync(Guid appointmentId, DateTime newDate)
    {
        var appointment = await _context.Appointments.FindAsync(appointmentId);
        if (appointment == null) return false;
        appointment.Date = newDate;
        appointment.Status = "Rescheduled";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
