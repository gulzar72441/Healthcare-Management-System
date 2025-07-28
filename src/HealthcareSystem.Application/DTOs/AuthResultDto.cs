namespace HealthcareSystem.Application.DTOs;

public class AuthResultDto
{
    public string Token { get; set; } = string.Empty;
    public string? RefreshToken { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool Success { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
