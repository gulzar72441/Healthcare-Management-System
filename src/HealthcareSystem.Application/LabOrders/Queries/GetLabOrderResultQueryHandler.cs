using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.LabOrders.Queries;

public class GetLabOrderResultQueryHandler : IRequestHandler<GetLabOrderResultQuery, string>
{
    private readonly ILabOrderRepository _labOrderRepository;
    public GetLabOrderResultQueryHandler(ILabOrderRepository labOrderRepository)
    {
        _labOrderRepository = labOrderRepository;
    }
    public async Task<string> Handle(GetLabOrderResultQuery request, CancellationToken cancellationToken)
    {
        var labOrder = await _labOrderRepository.GetByIdAsync(request.LabOrderId);
        return labOrder?.Result ?? "No result available.";
    }
}
