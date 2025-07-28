using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Patients.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Queries;

public class GetPatientSummaryQueryHandler : IRequestHandler<GetPatientSummaryQuery, PatientSummaryDto>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IBillRepository _billRepository;
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly ILabOrderRepository _labOrderRepository;

    public GetPatientSummaryQueryHandler(
        IAppointmentRepository appointmentRepository,
        IBillRepository billRepository,
        IPrescriptionRepository prescriptionRepository,
        ILabOrderRepository labOrderRepository)
    {
        _appointmentRepository = appointmentRepository;
        _billRepository = billRepository;
        _prescriptionRepository = prescriptionRepository;
        _labOrderRepository = labOrderRepository;
    }

    public async Task<PatientSummaryDto> Handle(GetPatientSummaryQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByPatientIdAsync(request.PatientId);
        var bills = await _billRepository.GetByPatientIdAsync(request.PatientId);
        var prescriptions = await _prescriptionRepository.GetByPatientIdAsync(request.PatientId);
        var labOrders = await _labOrderRepository.GetByPatientIdAsync(request.PatientId);
        return new PatientSummaryDto
        {
            PatientId = request.PatientId,
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
            Bills = bills.Select(b => new BillDto
            {
                Id = b.Id,
                PatientId = b.PatientId,
                Amount = b.Amount,
                Status = b.Status,
                DueDate = b.DueDate,
                CreatedAt = b.CreatedAt
            }).ToList(),
            Prescriptions = prescriptions.Select(p => new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                DoctorId = p.DoctorId,
                Date = p.Date,
                Medication = p.Medication,
                Instructions = p.Instructions
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
