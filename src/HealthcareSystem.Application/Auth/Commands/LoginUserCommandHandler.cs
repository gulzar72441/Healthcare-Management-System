using MediatR;
using HealthcareSystem.Application.Auth.Interfaces;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Auth.Commands;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    public LoginUserCommandHandler(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null || !user.VerifyPassword(request.Password))
            return string.Empty;
        return _jwtService.GenerateToken(user);
    }
} 