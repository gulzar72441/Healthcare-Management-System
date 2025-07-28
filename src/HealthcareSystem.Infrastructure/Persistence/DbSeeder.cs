using HealthcareSystem.Domain.Entities;
using Bogus;

namespace HealthcareSystem.Infrastructure.Persistence;

public static class DbSeeder
{
    public static void Seed(HealthcareDbContext context)
    {
        // --- Specialties ---
        if (!context.Specialties.Any())
        {
            var specialties = new[] { "Cardiology", "Dermatology", "Pediatrics", "Neurology", "Oncology", "Orthopedics" }
                .Select(name => new Specialty { Name = name }).ToList();
            context.Specialties.AddRange(specialties);
            context.SaveChanges();
        }
        var specialtiesList = context.Specialties.ToList();

        // --- Doctors ---
        if (!context.Doctors.Any())
        {
            var doctorFaker = new Faker<Doctor>()
                .RuleFor(d => d.Id, f => Guid.NewGuid())
                .RuleFor(d => d.FirstName, f => f.Name.FirstName())
                .RuleFor(d => d.LastName, f => f.Name.LastName())
                .RuleFor(d => d.Name, (f, d) => $"{d.FirstName} {d.LastName}")
                .RuleFor(d => d.Bio, f => f.Lorem.Paragraph())
                .RuleFor(d => d.Email, (f, d) => f.Internet.Email(d.FirstName, d.LastName))
                .RuleFor(d => d.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(d => d.Specialty, f => f.PickRandom(specialtiesList).Name);
            var doctors = doctorFaker.Generate(15);
            context.Doctors.AddRange(doctors);
            context.SaveChanges();
        }
        var doctorsList = context.Doctors.ToList();

        // --- Patients ---
        if (!context.Patients.Any())
        {
            var patientFaker = new Faker<Patient>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(60, DateTime.Today.AddYears(-18)))
                .RuleFor(p => p.Gender, f => f.PickRandom(new[] { "Male", "Female", "Other" }))
                .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName))
                .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.DoctorId, f => f.PickRandom(doctorsList).Id);
            var patients = patientFaker.Generate(20);
            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
        var patientsList = context.Patients.ToList();

        // --- Appointments ---
        if (!context.Appointments.Any())
        {
            var appointmentFaker = new Faker<Appointment>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.PatientId, f => f.PickRandom(patientsList).Id)
                .RuleFor(a => a.DoctorId, f => f.PickRandom(doctorsList).Id)
                .RuleFor(a => a.Date, f => f.Date.Soon(30))
                .RuleFor(a => a.Reason, f => f.Lorem.Sentence())
                .RuleFor(a => a.Status, f => f.PickRandom(new[] { "Booked", "Cancelled", "Rescheduled" }))
                .RuleFor(a => a.Notes, f => f.Lorem.Sentences(2));
            var appointments = appointmentFaker.Generate(25);
            context.Appointments.AddRange(appointments);
            context.SaveChanges();
        }

        // --- MedicalRecords ---
        if (!context.MedicalRecords.Any())
        {
            var medRecFaker = new Faker<MedicalRecord>()
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.PatientId, f => f.PickRandom(patientsList).Id)
                .RuleFor(m => m.Diagnosis, f => f.Lorem.Word())
                .RuleFor(m => m.History, f => f.Lorem.Sentence())
                .RuleFor(m => m.Treatments, f => f.Lorem.Sentence());
            var medRecords = medRecFaker.Generate(20);
            context.MedicalRecords.AddRange(medRecords);
            context.SaveChanges();
        }
        var medRecordsList = context.MedicalRecords.ToList();

        // --- Prescriptions ---
        if (!context.Prescriptions.Any())
        {
            var prescriptionFaker = new Faker<Prescription>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.PatientId, f => f.PickRandom(patientsList).Id)
                .RuleFor(p => p.DoctorId, f => f.PickRandom(doctorsList).Id)
                .RuleFor(p => p.Date, f => f.Date.Recent(60))
                .RuleFor(p => p.Medication, f => f.Commerce.ProductName())
                .RuleFor(p => p.Instructions, f => f.Lorem.Sentence());
            var prescriptions = prescriptionFaker.Generate(20);
            context.Prescriptions.AddRange(prescriptions);
            context.SaveChanges();
        }

        // --- Notifications ---
        if (!context.Notifications.Any())
        {
            var notificationFaker = new Faker<Notification>()
                .RuleFor(n => n.Id, f => Guid.NewGuid())
                .RuleFor(n => n.UserId, f => f.PickRandom(patientsList).Id)
                .RuleFor(n => n.Type, f => f.PickRandom(new[] { "Email", "SMS" }))
                .RuleFor(n => n.Status, f => f.PickRandom(new[] { "Pending", "Sent", "Failed" }))
                .RuleFor(n => n.Message, f => f.Lorem.Sentence())
                .RuleFor(n => n.CreatedAt, f => f.Date.Recent(30));
            var notifications = notificationFaker.Generate(20);
            context.Notifications.AddRange(notifications);
            context.SaveChanges();
        }

        // --- Users ---
        if (!context.Users.Any())
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Role, f => f.PickRandom(new[] { "Admin", "Doctor", "Patient" }))
                .RuleFor(u => u.PasswordHash, f => BCrypt.Net.BCrypt.HashPassword("abc123"));
            var users = userFaker.Generate(15);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        // --- Pharmacies ---
        if (!context.Pharmacies.Any())
        {
            var pharmacyFaker = new Faker<Pharmacy>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Company.CompanyName())
                .RuleFor(p => p.Address, f => f.Address.FullAddress());
            var pharmacies = pharmacyFaker.Generate(4);
            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();
        }
        var pharmaciesList = context.Pharmacies.ToList();

        // --- Medicines ---
        if (!context.Medicines.Any())
        {
            var medicineFaker = new Faker<Medicine>()
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.Name, f => f.Commerce.ProductName())
                .RuleFor(m => m.Stock, f => f.Random.Int(10, 500))
                .RuleFor(m => m.Manufacturer, f => f.Company.CompanyName())
                .RuleFor(m => m.PharmacyId, f => f.PickRandom(pharmaciesList).Id);
            var medicines = medicineFaker.Generate(30);
            context.Medicines.AddRange(medicines);
            context.SaveChanges();
        }
        var medicinesList = context.Medicines.ToList();

        // --- MedicalFiles ---
        if (!context.MedicalFiles.Any())
        {
            var medFileFaker = new Faker<MedicalFile>()
                .RuleFor(mf => mf.Id, f => Guid.NewGuid())
                .RuleFor(mf => mf.FileName, f => f.System.FileName())
                .RuleFor(mf => mf.FileUrl, f => f.Internet.Url())
                .RuleFor(mf => mf.UploadedAt, f => f.Date.Past(2));
            var medFiles = medFileFaker.Generate(20);
            context.MedicalFiles.AddRange(medFiles);
            context.SaveChanges();
        }
        var medFilesList = context.MedicalFiles.ToList();

        // --- LabOrders ---
        if (!context.LabOrders.Any())
        {
            var labOrderFaker = new Faker<LabOrder>()
                .RuleFor(l => l.Id, f => Guid.NewGuid())
                .RuleFor(l => l.PatientId, f => f.PickRandom(patientsList).Id)
                .RuleFor(l => l.DoctorId, f => f.PickRandom(doctorsList).Id)
                .RuleFor(l => l.TestType, f => f.Lorem.Word())
                .RuleFor(l => l.Date, f => f.Date.Recent(60))
                .RuleFor(l => l.Result, f => f.Lorem.Word())
                .RuleFor(l => l.ResultDate, f => f.Date.Recent(30));
            var labOrders = labOrderFaker.Generate(18);
            context.LabOrders.AddRange(labOrders);
            context.SaveChanges();
        }

        // --- DoctorSchedules ---
        if (!context.DoctorSchedules.Any())
        {
            var doctorScheduleFaker = new Faker<DoctorSchedule>()
                .RuleFor(ds => ds.Id, f => Guid.NewGuid())
                .RuleFor(ds => ds.DoctorId, f => f.PickRandom(doctorsList).Id)
                .RuleFor(ds => ds.StartTime, f => f.Date.Soon(7, DateTime.Today.AddHours(8)))
                .RuleFor(ds => ds.EndTime, (f, ds) => ds.StartTime.AddHours(f.Random.Int(1, 8)))
                .RuleFor(ds => ds.IsAvailable, f => f.Random.Bool());
            var doctorSchedules = doctorScheduleFaker.Generate(20);
            context.DoctorSchedules.AddRange(doctorSchedules);
            context.SaveChanges();
        }

        // --- Bills ---
        if (!context.Bills.Any())
        {
            var billFaker = new Faker<Bill>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.PatientId, f => f.PickRandom(patientsList).Id)
                .RuleFor(b => b.Amount, f => f.Random.Decimal(100, 10000))
                .RuleFor(b => b.Status, f => f.PickRandom(new[] { "Paid", "Unpaid", "Overdue" }))
                .RuleFor(b => b.DueDate, f => f.Date.Soon(30))
                .RuleFor(b => b.InsuranceInfo, f => f.Company.CompanyName())
                .RuleFor(b => b.CreatedAt, f => f.Date.Recent(60));
            var bills = billFaker.Generate(15);
            context.Bills.AddRange(bills);
            context.SaveChanges();
        }
        var billsList = context.Bills.ToList();

        // --- BillItems ---
        if (!context.BillItems.Any())
        {
            var billItemFaker = new Faker<BillItem>()
                .RuleFor(bi => bi.Id, f => Guid.NewGuid())
                .RuleFor(bi => bi.Description, f => f.Commerce.ProductName())
                .RuleFor(bi => bi.Amount, f => f.Random.Decimal(10, 200));
            var billItems = new List<BillItem>();
            foreach (var bill in billsList)
            {
                var items = billItemFaker.Generate(2);
                bill.Items = items;
                billItems.AddRange(items);
            }
            context.BillItems.AddRange(billItems);
            context.SaveChanges();
        }
    }
}
