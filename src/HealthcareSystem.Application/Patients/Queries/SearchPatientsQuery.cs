using HealthcareSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Patients.Queries;

public class SearchPatientsQuery : IRequest<IEnumerable<PatientDto>>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public SearchPatientsQuery(string? name, string? email, string? phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}
