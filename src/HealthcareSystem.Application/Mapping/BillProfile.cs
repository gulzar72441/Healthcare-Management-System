using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class BillProfile : Profile
{
    public BillProfile()
    {
        CreateMap<Bill, BillDto>().ReverseMap();
    }
}
