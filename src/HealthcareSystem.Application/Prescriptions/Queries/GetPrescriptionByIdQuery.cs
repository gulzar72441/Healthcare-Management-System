using HealthcareSystem.Application.DTOs;
using MediatR;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class GetPrescriptionByIdQuery : IRequest<PrescriptionDto?>
{
    public Guid Id { get; set; }
    public GetPrescriptionByIdQuery(Guid id) => Id = id;
}
