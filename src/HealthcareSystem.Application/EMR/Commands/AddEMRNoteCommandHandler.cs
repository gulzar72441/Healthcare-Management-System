using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Domain.Entities;
using AutoMapper;

namespace HealthcareSystem.Application.EMR.Commands;

public class AddEMRNoteCommandHandler : IRequestHandler<AddEMRNoteCommand, MedicalRecordDto>
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;
    private readonly IMapper _mapper;

    public AddEMRNoteCommandHandler(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
    {
        _medicalRecordRepository = medicalRecordRepository;
        _mapper = mapper;
    }

    public async Task<MedicalRecordDto> Handle(AddEMRNoteCommand request, CancellationToken cancellationToken)
    {
        var medicalRecord = new MedicalRecord
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            History = request.Note, // Assuming the 'note' is part of the medical history
            Diagnosis = request.Diagnosis, // Other fields can be populated later
            Treatments = request.Treatments
        };

        await _medicalRecordRepository.AddAsync(medicalRecord);

        return _mapper.Map<MedicalRecordDto>(medicalRecord);
    }
} 