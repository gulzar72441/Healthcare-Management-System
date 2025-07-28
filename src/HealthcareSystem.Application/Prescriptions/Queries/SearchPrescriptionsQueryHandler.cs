using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class SearchPrescriptionsQueryHandler : IRequestHandler<SearchPrescriptionsQuery, IEnumerable<PrescriptionDto>>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    public SearchPrescriptionsQueryHandler(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    public async Task<IEnumerable<PrescriptionDto>> Handle(SearchPrescriptionsQuery request, CancellationToken cancellationToken)
    {
        var prescriptions = await _prescriptionRepository.SearchAsync(request.Medication, request.Date, request.DoctorId, request.PatientId);
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
