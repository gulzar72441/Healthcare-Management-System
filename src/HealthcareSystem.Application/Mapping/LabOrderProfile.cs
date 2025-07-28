using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class LabOrderProfile : Profile
{
    public LabOrderProfile()
    {
        CreateMap<LabOrder, LabOrderDto>().ReverseMap();
    }
}
