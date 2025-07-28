using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class GetPrescriptionsByDoctorQueryHandler : IRequestHandler<GetPrescriptionsByDoctorQuery, IEnumerable<PrescriptionDto>>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    public GetPrescriptionsByDoctorQueryHandler(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    public async Task<IEnumerable<PrescriptionDto>> Handle(GetPrescriptionsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var prescriptions = await _prescriptionRepository.GetByDoctorIdAsync(request.DoctorId);
        return prescriptions.Select(p => new PrescriptionDto
        {
            Id = p.Id,
            PatientId = p.PatientId,
            DoctorId = p.DoctorId,
            Date = p.Date,
            Medication = p.Medication,
            Dosage = p.Dosage,
            Instructions = p.Instructions
        });
    }
}
