using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Queries;

public class SearchPatientsQueryHandler : IRequestHandler<SearchPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;
    public SearchPatientsQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<PatientDto>> Handle(SearchPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.SearchAsync(request.Name, request.Email, request.Phone);
        return patients.Select(p => new PatientDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            Phone = p.Phone,
            DateOfBirth = p.DateOfBirth,
            Address = p.Address,
            DoctorId = (Guid)p.DoctorId
        });
    }
}
