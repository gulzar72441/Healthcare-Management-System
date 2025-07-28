using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Auth.Queries;

public class GetCurrentUserQuery : IRequest<UserDto?>
{
    public string Username { get; set; } = string.Empty;
    public GetCurrentUserQuery(string username) => Username = username;
}
