using MediatR;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetDoctorSpecialtiesQuery : IRequest<IEnumerable<string>>
{
}
