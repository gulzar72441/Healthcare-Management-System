using HealthcareSystem.Application.Doctors.DTOs;
using MediatR;
using System;

namespace HealthcareSystem.Application.Doctors.Queries;

public class GetDoctorDashboardQuery : IRequest<DoctorDashboardDto>
{
    public Guid DoctorId { get; set; }
    public GetDoctorDashboardQuery(Guid doctorId) => DoctorId = doctorId;
}
