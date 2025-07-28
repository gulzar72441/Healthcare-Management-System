using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Billing.Queries;

public class SearchBillsQueryHandler : IRequestHandler<SearchBillsQuery, IEnumerable<BillDto>>
{
    private readonly IBillRepository _billRepository;
    public SearchBillsQueryHandler(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<IEnumerable<BillDto>> Handle(SearchBillsQuery request, CancellationToken cancellationToken)
    {
        var bills = await _billRepository.SearchAsync(request.Status, request.FromDate, request.ToDate, request.PatientId, request.DoctorId);
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
