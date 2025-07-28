using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetOverdueBillsQueryHandler : IRequestHandler<GetOverdueBillsQuery, IEnumerable<BillDto>>
{
    private readonly IBillRepository _billRepository;
    public GetOverdueBillsQueryHandler(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<IEnumerable<BillDto>> Handle(GetOverdueBillsQuery request, CancellationToken cancellationToken)
    {
        var bills = await _billRepository.GetOverdueAsync();
        return bills.Select(b => new BillDto
        {
            Id = b.Id,
            PatientId = b.PatientId,
            Amount = b.Amount,
            Status = b.Status,
            DueDate = b.DueDate,
            InsuranceInfo = b.InsuranceInfo,
            CreatedAt = b.CreatedAt
        });
    }
}
