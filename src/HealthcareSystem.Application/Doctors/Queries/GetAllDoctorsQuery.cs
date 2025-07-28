using MediatR;
using HealthcareSystem.Application.DTOs;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetAllDoctorsQuery : IRequest<IEnumerable<DoctorDto>>
{
}
