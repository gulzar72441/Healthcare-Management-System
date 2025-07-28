using MediatR;
using HealthcareSystem.Application.Pharmacy.Interfaces;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Pharmacy.Commands;

public class SendPrescriptionToPharmacyCommandHandler : IRequestHandler<SendPrescriptionToPharmacyCommand, bool>
{
    private readonly IPharmacyService _pharmacyService;
    public SendPrescriptionToPharmacyCommandHandler(IPharmacyService pharmacyService)
    {
        _pharmacyService = pharmacyService;
    }

    public async Task<bool> Handle(SendPrescriptionToPharmacyCommand request, CancellationToken cancellationToken)
    {
        return await _pharmacyService.SendPrescriptionAsync(request.PrescriptionId);
    }
} 