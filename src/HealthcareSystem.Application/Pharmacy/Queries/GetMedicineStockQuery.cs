using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Pharmacy.Queries;

public class GetMedicineStockQuery : IRequest<IEnumerable<MedicineStockDto>>
{
    public Guid PharmacyId { get; set; }
    public GetMedicineStockQuery(Guid pharmacyId) => PharmacyId = pharmacyId;
}
