using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.LabOrders.Commands;

public class MarkLabOrderReviewedCommandHandler : IRequestHandler<MarkLabOrderReviewedCommand, bool>
{
    private readonly ILabOrderRepository _labOrderRepository;
    public MarkLabOrderReviewedCommandHandler(ILabOrderRepository labOrderRepository)
    {
        _labOrderRepository = labOrderRepository;
    }
    public async Task<bool> Handle(MarkLabOrderReviewedCommand request, CancellationToken cancellationToken)
    {
        return await _labOrderRepository.MarkReviewedAsync(request.LabOrderId);
    }
}
