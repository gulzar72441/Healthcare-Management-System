using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetPaidBillsQueryHandler : IRequestHandler<GetPaidBillsQuery, IEnumerable<BillDto>>
{
    private readonly IBillRepository _billRepository;
    public GetPaidBillsQueryHandler(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<IEnumerable<BillDto>> Handle(GetPaidBillsQuery request, CancellationToken cancellationToken)
    {
        var bills = await _billRepository.GetPaidAsync();
        return bills.Select(b => new BillDto
        {
            Id = b.Id,
            PatientId = b.PatientId,
            Amount = b.Amount,
            Status = b.Status,
            InsuranceInfo = b.InsuranceInfo,
            DueDate = b.DueDate
        });
    }
}
