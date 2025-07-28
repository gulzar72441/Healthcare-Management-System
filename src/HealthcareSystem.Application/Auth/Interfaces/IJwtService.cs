namespace HealthcareSystem.Application.Auth.Interfaces;

using HealthcareSystem.Domain.Entities;

public interface IJwtService
{
    string GenerateToken(User user);
}
