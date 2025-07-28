using HealthcareSystem.Application.DTOs;
using MediatR;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetBillByIdQuery : IRequest<BillDto?>
{
    public Guid Id { get; set; }
    public GetBillByIdQuery(Guid id) => Id = id;
}
