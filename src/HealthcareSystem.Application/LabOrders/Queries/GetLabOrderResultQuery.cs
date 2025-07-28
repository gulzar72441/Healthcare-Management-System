using MediatR;
using System;

namespace HealthcareSystem.Application.LabOrders.Queries;

public class GetLabOrderResultQuery : IRequest<string>
{
    public Guid LabOrderId { get; }
    public GetLabOrderResultQuery(Guid labOrderId) => LabOrderId = labOrderId;
}
