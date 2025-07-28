using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Pharmacy.Commands;

public class SendPrescriptionCommandHandler : IRequestHandler<SendPrescriptionCommand, PrescriptionDto>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMapper _mapper;
    public SendPrescriptionCommandHandler(IPrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _mapper = mapper;
    }

    public async Task<PrescriptionDto> Handle(SendPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescription = new Prescription
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            Medication = request.Medication,
            Dosage = request.Dosage,
            Instructions = request.Instructions,
            Date = DateTime.UtcNow,
            DateIssued = DateTime.UtcNow
        };
        await _prescriptionRepository.AddAsync(prescription);
        return _mapper.Map<PrescriptionDto>(prescription);

    }
}
