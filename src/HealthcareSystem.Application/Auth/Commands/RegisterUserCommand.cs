using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Auth.Commands;

public class RegisterUserCommand : IRequest<UserDto>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
