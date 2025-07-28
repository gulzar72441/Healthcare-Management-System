using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto?>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<DoctorDto?> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.Id);
        return doctor == null ? null : _mapper.Map<DoctorDto>(doctor);
    }
}
