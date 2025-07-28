using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Dashboard.Queries;

public class GetDashboardSummaryQueryHandler : IRequestHandler<GetDashboardSummaryQuery, DashboardSummaryDto>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IBillRepository _billRepository;

    public GetDashboardSummaryQueryHandler(
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IAppointmentRepository appointmentRepository,
        IBillRepository billRepository)
    {
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _appointmentRepository = appointmentRepository;
        _billRepository = billRepository;
    }

    public async Task<DashboardSummaryDto> Handle(GetDashboardSummaryQuery request, CancellationToken cancellationToken)
    {
        var patients = await _patientRepository.GetAllAsync();
        var doctors = await _doctorRepository.GetAllAsync();
        var appointments = await _appointmentRepository.GetAllAsync();
        var bills = await _billRepository.SearchAsync(null, null, null, null, null);

        return new DashboardSummaryDto
        {
            TotalPatients = patients.Count(),
            TotalDoctors = doctors.Count(),
            TotalAppointments = appointments.Count(),
            TotalBills = bills.Count(),
            TotalRevenue = bills.Sum(b => b.Amount)
        };
    }
}
