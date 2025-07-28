using MediatR;
using System;

namespace HealthcareSystem.Application.LabOrders.Commands;

public class MarkLabOrderReviewedCommand : IRequest<bool>
{
    public Guid LabOrderId { get; }
    public MarkLabOrderReviewedCommand(Guid labOrderId) => LabOrderId = labOrderId;
}
