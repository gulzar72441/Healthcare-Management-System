using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>().ReverseMap();
    }
}
