using MediatR;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Billing.Commands;

public class PayBillCommandHandler : IRequestHandler<PayBillCommand, bool>
{
    private readonly IBillRepository _billRepository;
    public PayBillCommandHandler(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public async Task<bool> Handle(PayBillCommand request, CancellationToken cancellationToken)
    {
        var bill = await _billRepository.GetByIdAsync(request.BillId);
        if (bill == null || bill.Status == "Paid")
            return false;
        bill.Status = "Paid";
        await _billRepository.UpdateAsync(bill);
        return true;
    }
} 