using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Queries;

public class SearchDoctorsQueryHandler : IRequestHandler<SearchDoctorsQuery, IEnumerable<DoctorDto>>
{
    private readonly IDoctorRepository _doctorRepository;
    public SearchDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IEnumerable<DoctorDto>> Handle(SearchDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _doctorRepository.SearchAsync(request.Name, request.Specialty);
        return doctors.Select(d => new DoctorDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            Email = d.Email,
            Specialty = d.Specialty
        });
    }
}
