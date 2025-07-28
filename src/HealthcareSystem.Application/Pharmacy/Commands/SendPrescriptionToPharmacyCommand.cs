using MediatR;

namespace HealthcareSystem.Application.Pharmacy.Commands;

public class SendPrescriptionToPharmacyCommand : IRequest<bool>
{
    public Guid PrescriptionId { get; set; }
    public SendPrescriptionToPharmacyCommand(Guid prescriptionId) => PrescriptionId = prescriptionId;
}
