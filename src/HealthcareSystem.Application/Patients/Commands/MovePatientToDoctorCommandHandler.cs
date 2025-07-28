using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Patients.Commands;

public class MovePatientToDoctorCommandHandler : IRequestHandler<MovePatientToDoctorCommand, bool>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    public MovePatientToDoctorCommandHandler(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
    }

    public async Task<bool> Handle(MovePatientToDoctorCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);
        var doctor = await _doctorRepository.GetByIdAsync(request.NewDoctorId);
        if (patient == null || doctor == null) return false;
        patient.DoctorId = doctor.Id; // Assumes Patient has DoctorId property
        await _patientRepository.UpdateAsync(patient);
        return true;
    }
}
