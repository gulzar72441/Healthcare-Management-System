using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Doctors.Commands;

public class CreateDoctorCommand : IRequest<DoctorDto>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
}
