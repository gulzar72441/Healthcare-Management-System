using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorDto>>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _doctorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
    }
}
