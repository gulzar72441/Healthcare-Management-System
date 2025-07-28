using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Doctors.Commands;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
{
    private readonly IDoctorRepository _doctorRepository;
    public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Specialty = request.Specialty
        };
        await _doctorRepository.AddAsync(doctor);
        return new DoctorDto
        {
            Id = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email,
            Phone = doctor.Phone,
            Specialty = doctor.Specialty
        };
    }
}
