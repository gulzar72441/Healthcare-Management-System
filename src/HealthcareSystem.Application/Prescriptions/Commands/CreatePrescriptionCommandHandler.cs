using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Domain.Entities;
using AutoMapper;

namespace HealthcareSystem.Application.Prescriptions.Commands;

public class CreatePrescriptionCommandHandler : IRequestHandler<CreatePrescriptionCommand, PrescriptionDto>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMapper _mapper;

    public CreatePrescriptionCommandHandler(IPrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _mapper = mapper;
    }

    public async Task<PrescriptionDto> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        // Map command to domain entity (assume Prescription entity exists)
        var prescription = new Prescription
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            Medication = request.Medication,
            Instructions = request.Instructions,
            Dosage = request.Dosage,
            Date = DateTime.UtcNow,
            DateIssued = DateTime.UtcNow
        };
        await _prescriptionRepository.AddAsync(prescription);
        return _mapper.Map<PrescriptionDto>(prescription);
    }
} 