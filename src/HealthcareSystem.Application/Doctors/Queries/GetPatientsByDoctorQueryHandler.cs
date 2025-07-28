using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetPatientsByDoctorQueryHandler : IRequestHandler<GetPatientsByDoctorQuery, IEnumerable<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;
    public GetPatientsByDoctorQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<PatientDto>> Handle(GetPatientsByDoctorQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetByDoctorIdAsync(request.DoctorId);
        return patients.Select(p => new PatientDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Phone = p.Phone,
            DateOfBirth = p.DateOfBirth
        });
    }
}
