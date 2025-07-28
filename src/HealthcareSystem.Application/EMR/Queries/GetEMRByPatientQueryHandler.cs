using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.EMR.Queries;

public class GetEMRByPatientQueryHandler : IRequestHandler<GetEMRByPatientQuery, IEnumerable<MedicalRecordDto>>
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;
    private readonly IMapper _mapper;
    public GetEMRByPatientQueryHandler(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
    {
        _medicalRecordRepository = medicalRecordRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalRecordDto>> Handle(GetEMRByPatientQuery request, CancellationToken cancellationToken)
    {
        var records = await _medicalRecordRepository.GetByPatientIdAsync(request.PatientId);
        return _mapper.Map<IEnumerable<MedicalRecordDto>>(records);
    }
}
