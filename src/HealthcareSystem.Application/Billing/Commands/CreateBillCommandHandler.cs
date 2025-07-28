using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Domain.Entities;
using AutoMapper;

namespace HealthcareSystem.Application.Billing.Commands;

public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, BillDto>
{
    private readonly IBillRepository _billRepository;
    private readonly IMapper _mapper;
    public CreateBillCommandHandler(IBillRepository billRepository, IMapper mapper)
    {
        _billRepository = billRepository;
        _mapper = mapper;
    }

    public async Task<BillDto> Handle(CreateBillCommand request, CancellationToken cancellationToken)
    {
        var bill = new Bill
        {
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow,
            Status = "Unpaid",
            InsuranceInfo = request.InsuranceInfo,
            DueDate = DateTime.UtcNow.AddDays(30)
        };
        await _billRepository.AddAsync(bill);
        return _mapper.Map<BillDto>(bill);
    }
} 