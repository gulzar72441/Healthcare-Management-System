using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class PrescriptionProfile : Profile
{
    public PrescriptionProfile()
    {
        CreateMap<Prescription, PrescriptionDto>().ReverseMap();
    }
}
