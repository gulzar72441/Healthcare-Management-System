using AutoMapper;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Mapping;

public class MedicalRecordProfile : Profile
{
    public MedicalRecordProfile()
    {
        CreateMap<MedicalRecord, MedicalRecordDto>().ReverseMap();
    }
}
