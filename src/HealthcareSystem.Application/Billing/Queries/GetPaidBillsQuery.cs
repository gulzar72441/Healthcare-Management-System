using HealthcareSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetPaidBillsQuery : IRequest<IEnumerable<BillDto>>
{
}
