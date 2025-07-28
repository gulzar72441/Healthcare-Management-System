using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;
using AutoMapper;

namespace HealthcareSystem.Application.Prescriptions.Queries;

public class GetPrescriptionByIdQueryHandler : IRequestHandler<GetPrescriptionByIdQuery, PrescriptionDto?>
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly IMapper _mapper;

    public GetPrescriptionByIdQueryHandler(IPrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _mapper = mapper;
    }

    public async Task<PrescriptionDto?> Handle(GetPrescriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var prescription = await _prescriptionRepository.GetByIdAsync(request.Id);
        return prescription == null ? null : _mapper.Map<PrescriptionDto>(prescription);
    }
}
