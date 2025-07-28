using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Pharmacy.Queries;

public class GetMedicineStockQueryHandler : IRequestHandler<GetMedicineStockQuery, IEnumerable<MedicineStockDto>>
{
    private readonly IPharmacyRepository _pharmacyRepository;
    public GetMedicineStockQueryHandler(IPharmacyRepository pharmacyRepository)
    {
        _pharmacyRepository = pharmacyRepository;
    }

    public async Task<IEnumerable<MedicineStockDto>> Handle(GetMedicineStockQuery request, CancellationToken cancellationToken)
    {
        var medicines = await _pharmacyRepository.GetMedicineStockAsync(request.PharmacyId);
        var dtos = new List<MedicineStockDto>();
        foreach (var med in medicines)
        {
            dtos.Add(new MedicineStockDto
            {
                MedicineId = med.Id,
                Name = med.Name,
                Quantity = med.Stock
            });
        }
        return dtos;
    }
}
