using HealthcareSystem.Application.Pharmacy.Interfaces;
using HealthcareSystem.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace HealthcareSystem.Infrastructure.Services;

public class PharmacyService : IPharmacyService
{
    private readonly IPrescriptionRepository _prescriptionRepository;
    private readonly ILogger<PharmacyService> _logger;

    public PharmacyService(IPrescriptionRepository prescriptionRepository, ILogger<PharmacyService> logger)
    {
        _prescriptionRepository = prescriptionRepository;
        _logger = logger;
    }

    public async Task<bool> SendPrescriptionAsync(Guid prescriptionId)
    {
        var prescription = await _prescriptionRepository.GetByIdAsync(prescriptionId);
        if (prescription == null)
        {
            _logger.LogWarning("Prescription with ID {PrescriptionId} not found.", prescriptionId);
            return false;
        }

        // In a real-world scenario, this would integrate with an external pharmacy system API.
        // For this example, we'll just log the action and assume success.
        _logger.LogInformation("Sending prescription {PrescriptionId} to the pharmacy.", prescription.Id);

        // Simulate API call
        await Task.Delay(500); // Simulate network latency

        _logger.LogInformation("Prescription {PrescriptionId} sent successfully.", prescription.Id);

        return true;
    }
}
