using MediatR;
using HealthcareSystem.Application.DTOs;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetDoctorByIdQuery : IRequest<DoctorDto?>
{
    public Guid Id { get; set; }
    public GetDoctorByIdQuery(Guid id) => Id = id;
}
