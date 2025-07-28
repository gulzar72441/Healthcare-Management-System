using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;
using AutoMapper;

namespace HealthcareSystem.Application.LabOrders.Queries;

public class GetLabOrderByIdQueryHandler : IRequestHandler<GetLabOrderByIdQuery, LabOrderDto?>
{
    private readonly ILabOrderRepository _labOrderRepository;
    private readonly IMapper _mapper;

    public GetLabOrderByIdQueryHandler(ILabOrderRepository labOrderRepository, IMapper mapper)
    {
        _labOrderRepository = labOrderRepository;
        _mapper = mapper;
    }

    public async Task<LabOrderDto?> Handle(GetLabOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var labOrder = await _labOrderRepository.GetByIdAsync(request.Id);
        return labOrder == null ? null : _mapper.Map<LabOrderDto>(labOrder);
    }
}
