using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;
using AutoMapper;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetBillByIdQueryHandler : IRequestHandler<GetBillByIdQuery, BillDto?>
{
    private readonly IBillRepository _billRepository;
    private readonly IMapper _mapper;

    public GetBillByIdQueryHandler(IBillRepository billRepository, IMapper mapper)
    {
        _billRepository = billRepository;
        _mapper = mapper;
    }

    public async Task<BillDto?> Handle(GetBillByIdQuery request, CancellationToken cancellationToken)
    {
        var bill = await _billRepository.GetByIdAsync(request.Id);
        return bill == null ? null : _mapper.Map<BillDto>(bill);
    }
}
