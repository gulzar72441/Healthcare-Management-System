using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.LabOrders.Queries;

public class SearchLabOrdersQueryHandler : IRequestHandler<SearchLabOrdersQuery, IEnumerable<LabOrderDto>>
{
    private readonly ILabOrderRepository _labOrderRepository;
    public SearchLabOrdersQueryHandler(ILabOrderRepository labOrderRepository)
    {
        _labOrderRepository = labOrderRepository;
    }

    public async Task<IEnumerable<LabOrderDto>> Handle(SearchLabOrdersQuery request, CancellationToken cancellationToken)
    {
        var labOrders = await _labOrderRepository.SearchAsync(request.TestType, request.Date, request.DoctorId, request.PatientId);
        return labOrders.Select(l => new LabOrderDto
        {
            Id = l.Id,
            PatientId = l.PatientId,
            DoctorId = l.DoctorId,
            Date = l.Date,
            TestType = l.TestType,
            Result = l.Result,
            ResultDate = l.ResultDate
        });
    }
}
