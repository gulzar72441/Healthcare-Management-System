using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Auth.Queries;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetCurrentUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }
}
