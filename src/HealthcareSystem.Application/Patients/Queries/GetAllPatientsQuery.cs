using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Patients.Queries;

public class GetAllPatientsQuery : IRequest<IEnumerable<PatientDto>>
{
}
