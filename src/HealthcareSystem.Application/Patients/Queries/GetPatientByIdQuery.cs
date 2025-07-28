using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Patients.Queries;

public class GetPatientByIdQuery : IRequest<PatientDto?>
{
    public Guid Id { get; set; }
    public GetPatientByIdQuery(Guid id) => Id = id;
}
