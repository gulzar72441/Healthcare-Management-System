using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareSystem.Infrastructure.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly HealthcareDbContext _context;
        public MedicalRecordRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalRecord?> GetByIdAsync(Guid id)
        {
            return await _context.MedicalRecords.Include(m => m.Files).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(Guid patientId)
        {
            return await _context.MedicalRecords.Include(m => m.Files).Where(m => m.PatientId == patientId).ToListAsync();
        }

        public async Task AddAsync(MedicalRecord record)
        {
            await _context.MedicalRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicalRecord record)
        {
            _context.MedicalRecords.Update(record);
            await _context.SaveChangesAsync();
        }
    }
}
