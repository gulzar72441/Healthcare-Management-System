using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Domain.Entities;
using AutoMapper;

namespace HealthcareSystem.Application.Labs.Commands;

public class CreateLabOrderCommandHandler : IRequestHandler<CreateLabOrderCommand, LabOrderDto>
{
    private readonly ILabOrderRepository _labOrderRepository;
    private readonly IMapper _mapper;
    public CreateLabOrderCommandHandler(ILabOrderRepository labOrderRepository, IMapper mapper)
    {
        _labOrderRepository = labOrderRepository;
        _mapper = mapper;
    }

    public async Task<LabOrderDto> Handle(CreateLabOrderCommand request, CancellationToken cancellationToken)
    {
        var labOrder = new LabOrder
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            TestType = request.TestType,
            Date = DateTime.UtcNow
        };
        await _labOrderRepository.AddAsync(labOrder);
        return _mapper.Map<LabOrderDto>(labOrder);
    }
}