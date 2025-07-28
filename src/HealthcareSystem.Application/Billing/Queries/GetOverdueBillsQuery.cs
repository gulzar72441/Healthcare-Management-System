using HealthcareSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetOverdueBillsQuery : IRequest<IEnumerable<BillDto>>
{
}
