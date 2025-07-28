using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Labs.Queries;

public class GetLabResultsByPatientQueryHandler : IRequestHandler<GetLabResultsByPatientQuery, IEnumerable<LabOrderDto>>
{
    private readonly ILabOrderRepository _labOrderRepository;
    private readonly IMapper _mapper;
    public GetLabResultsByPatientQueryHandler(ILabOrderRepository labOrderRepository, IMapper mapper)
    {
        _labOrderRepository = labOrderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LabOrderDto>> Handle(GetLabResultsByPatientQuery request, CancellationToken cancellationToken)
    {
        var results = await _labOrderRepository.GetByPatientIdAsync(request.PatientId);
        return _mapper.Map<IEnumerable<LabOrderDto>>(results);
    }
}
