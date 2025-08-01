using MediatR;

namespace HealthcareSystem.Application.Auth.Commands;

public class LoginUserCommand : IRequest<string>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
