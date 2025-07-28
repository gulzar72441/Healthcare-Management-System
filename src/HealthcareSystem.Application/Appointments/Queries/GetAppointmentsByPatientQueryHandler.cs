using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Appointments.Queries;

public class GetAppointmentsByPatientQueryHandler : IRequestHandler<GetAppointmentsByPatientQuery, IEnumerable<AppointmentDto>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    public GetAppointmentsByPatientQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsByPatientQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetByPatientIdAsync(request.PatientId);
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }
}
