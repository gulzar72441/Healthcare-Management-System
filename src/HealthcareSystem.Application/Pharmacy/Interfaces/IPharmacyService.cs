namespace HealthcareSystem.Application.Pharmacy.Interfaces;

public interface IPharmacyService
{
    Task<bool> SendPrescriptionAsync(Guid prescriptionId);
}
