using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Doctors.Commands;

public class UpdateDoctorCommand : IRequest<DoctorDto>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
}
