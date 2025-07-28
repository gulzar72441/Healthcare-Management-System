using HealthcareSystem.Application.Doctors.DTOs;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetDoctorDashboardQueryHandler : IRequestHandler<GetDoctorDashboardQuery, DoctorDashboardDto>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly ILabOrderRepository _labOrderRepository;

    public GetDoctorDashboardQueryHandler(
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository,
        IPrescriptionRepository prescriptionRepository,
        ILabOrderRepository labOrderRepository)
    {
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
        _prescriptionRepository = prescriptionRepository;
        _labOrderRepository = labOrderRepository;
    }

    public async Task<DoctorDashboardDto> Handle(GetDoctorDashboardQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetByDoctorIdAsync(request.DoctorId);
        var appointments = await _appointmentRepository.GetByDoctorIdAsync(request.DoctorId);
        var prescriptions = await _prescriptionRepository.GetByDoctorIdAsync(request.DoctorId);
        var labOrders = await _labOrderRepository.GetByDoctorIdAsync(request.DoctorId);
        return new DoctorDashboardDto
        {
            DoctorId = request.DoctorId,
            Patients = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                Gender = p.Gender,
                Address =p.Address,
                DateOfBirth = p.DateOfBirth
            }).ToList(),
            Appointments = appointments.Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                Date = a.Date,
                Reason = a.Reason,
                Status = a.Status,
                Notes = a.Notes
            }).ToList(),
            Prescriptions = prescriptions.Select(pr => new PrescriptionDto
            {
                Id = pr.Id,
                PatientId = pr.PatientId,
                DoctorId = pr.DoctorId,
                Date = pr.Date,
                Medication = pr.Medication,
                Instructions = pr.Instructions
            }).ToList(),
            LabOrders = labOrders.Select(l => new LabOrderDto
            {
                Id = l.Id,
                PatientId = l.PatientId,
                DoctorId = l.DoctorId,
                Date = l.Date,
                TestType = l.TestType,
                Result = l.Result,
                ResultDate = l.ResultDate
            }).ToList()
        };
    }
}
