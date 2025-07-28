using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Domain.Entities;
using AutoMapper;

namespace HealthcareSystem.Application.Auth.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            Email = request.Email,
            Role = request.Role
        };
        user.SetPassword(request.Password);
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }
} 