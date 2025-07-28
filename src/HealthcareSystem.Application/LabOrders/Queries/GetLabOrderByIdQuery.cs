using HealthcareSystem.Application.DTOs;
using MediatR;

namespace HealthcareSystem.Application.LabOrders.Queries;

public class GetLabOrderByIdQuery : IRequest<LabOrderDto?>
{
    public Guid Id { get; set; }
    public GetLabOrderByIdQuery(Guid id) => Id = id;
}
