using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Dashboard.Queries;

public class GetDashboardSummaryQuery : IRequest<DashboardSummaryDto>
{
}
