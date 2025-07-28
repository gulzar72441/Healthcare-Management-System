using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Domain.Entities;

namespace HealthcareSystem.Infrastructure.Persistence;

public class HealthcareDbContext : DbContext
{
    public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
    public DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
    public DbSet<Prescription> Prescriptions { get; set; } = null!;
    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<LabOrder> LabOrders { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Pharmacy> Pharmacies { get; set; } = null!;
    public DbSet<Medicine> Medicines { get; set; } = null!;
    public DbSet<Specialty> Specialties { get; set; } = null!;
    public DbSet<MedicalFile> MedicalFiles { get; set; } = null!;
    public DbSet<DoctorSchedule> DoctorSchedules { get; set; } = null!;
    public DbSet<BillItem> BillItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Fluent API configurations can be added here
    }
}
