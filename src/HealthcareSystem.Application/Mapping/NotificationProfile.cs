using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<Notification, NotificationDto>().ReverseMap();
    }
}
