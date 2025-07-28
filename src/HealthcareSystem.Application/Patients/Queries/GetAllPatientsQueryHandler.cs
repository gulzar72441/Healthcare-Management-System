using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Queries;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    public GetAllPatientsQueryHandler(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientDto>>(patients);
    }
}
