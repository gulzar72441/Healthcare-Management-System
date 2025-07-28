using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Billing.Queries;

public class GetBillsByPatientQueryHandler : IRequestHandler<GetBillsByPatientQuery, IEnumerable<BillDto>>
{
    private readonly IBillRepository _billRepository;
    private readonly IMapper _mapper;
    public GetBillsByPatientQueryHandler(IBillRepository billRepository, IMapper mapper)
    {
        _billRepository = billRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BillDto>> Handle(GetBillsByPatientQuery request, CancellationToken cancellationToken)
    {
        var bills = await _billRepository.GetByPatientIdAsync(request.PatientId);
        return _mapper.Map<IEnumerable<BillDto>>(bills);
    }
}
