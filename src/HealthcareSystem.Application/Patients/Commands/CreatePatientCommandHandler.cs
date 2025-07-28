using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Commands;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    public CreatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Name = request.FirstName + ' ' + request.LastName,
            DoctorId = request.DoctorId,
            Email = request.Email,
            Phone = request.Phone,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Address = request.Address
        };
        await _patientRepository.AddAsync(patient);
        return _mapper.Map<PatientDto>(patient);
    }
}
