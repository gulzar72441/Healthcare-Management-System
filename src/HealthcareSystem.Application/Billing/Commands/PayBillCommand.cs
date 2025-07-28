using MediatR;

namespace HealthcareSystem.Application.Billing.Commands;

public class PayBillCommand : IRequest<bool>
{
    public Guid BillId { get; set; }
    public PayBillCommand(Guid billId) => BillId = billId;
}
