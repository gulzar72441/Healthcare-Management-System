using MediatR;

namespace HealthcareSystem.Application.Patients.Commands;

public class DeletePatientCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public DeletePatientCommand(Guid id) => Id = id;
}
