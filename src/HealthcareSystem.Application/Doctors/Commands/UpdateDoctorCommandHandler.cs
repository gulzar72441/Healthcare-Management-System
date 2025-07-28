using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Doctors.Commands;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDto>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<DoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByIdAsync(request.Id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with Id {request.Id} not found.");
        doctor.Name = request.Name;
        doctor.Specialty = request.Specialty;
        doctor.Email = request.Email;
        doctor.Phone = request.Phone;
        doctor.Bio = request.Bio;
        await _doctorRepository.UpdateAsync(doctor);
        return _mapper.Map<DoctorDto>(doctor);
    }
}
