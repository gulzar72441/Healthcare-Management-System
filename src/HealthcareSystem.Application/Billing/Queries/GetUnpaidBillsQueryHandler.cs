using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetUnpaidBillsQueryHandler : IRequestHandler<GetUnpaidBillsQuery, IEnumerable<BillDto>>
{
    private readonly IBillRepository _billRepository;
    public GetUnpaidBillsQueryHandler(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<IEnumerable<BillDto>> Handle(GetUnpaidBillsQuery request, CancellationToken cancellationToken)
    {
        var bills = await _billRepository.GetUnpaidAsync();
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
