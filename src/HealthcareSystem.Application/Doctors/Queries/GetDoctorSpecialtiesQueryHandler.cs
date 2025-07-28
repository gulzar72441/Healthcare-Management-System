using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetDoctorSpecialtiesQueryHandler : IRequestHandler<GetDoctorSpecialtiesQuery, IEnumerable<string>>
{
    private readonly IDoctorRepository _doctorRepository;
    public GetDoctorSpecialtiesQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IEnumerable<string>> Handle(GetDoctorSpecialtiesQuery request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.GetSpecialtiesAsync();
    }
}
