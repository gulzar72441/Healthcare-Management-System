using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
