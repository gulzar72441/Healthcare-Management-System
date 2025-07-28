using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Commands;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientDto>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    public UpdatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.Id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with Id {request.Id} not found.");
        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.Email = request.Email;
        patient.Phone = request.Phone;
        patient.DateOfBirth = request.DateOfBirth;
        patient.Gender = request.Gender;
        patient.Address = request.Address;
        patient.Name = request.FirstName + ' ' + request.LastName;
        await _patientRepository.UpdateAsync(patient);
        return _mapper.Map<PatientDto>(patient);
    }
}
