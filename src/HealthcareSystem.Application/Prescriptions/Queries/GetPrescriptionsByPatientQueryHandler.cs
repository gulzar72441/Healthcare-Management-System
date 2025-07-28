using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Prescriptions.Queries
{
    public class GetPrescriptionsByPatientQueryHandler : IRequestHandler<GetPrescriptionsByPatientQuery, IEnumerable<PrescriptionDto>>
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public GetPrescriptionsByPatientQueryHandler(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<IEnumerable<PrescriptionDto>> Handle(GetPrescriptionsByPatientQuery request, CancellationToken cancellationToken)
        {
            var prescriptions = await _prescriptionRepository.GetByPatientIdAsync(request.PatientId);
            var dtos = new List<PrescriptionDto>();
            foreach (var p in prescriptions)
            {
                dtos.Add(new PrescriptionDto
                {
                    Id = p.Id,
                    PatientId = p.PatientId,
                    DoctorId = p.DoctorId,
                    Date = p.Date,
                    Medication = p.Medication,
                    Instructions = p.Instructions,
                    Dosage = p.Dosage
                });
            }
            return dtos;
        }
    }
}
