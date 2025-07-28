using HealthcareSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Doctors.Queries;

public class SearchDoctorsQuery : IRequest<IEnumerable<DoctorDto>>
{
    public string? Name { get; set; }
    public string? Specialty { get; set; }
    public SearchDoctorsQuery(string? name, string? specialty)
    {
        Name = name;
        Specialty = specialty;
    }
}
