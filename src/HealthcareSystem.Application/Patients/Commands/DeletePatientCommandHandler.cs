using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Commands;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
{
    private readonly IPatientRepository _patientRepository;
    public DeletePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.Id);
        if (patient == null)
            return false;
        await _patientRepository.DeleteAsync(patient.Id);
        return true;
    }
}
