namespace HealthcareSystem.Application.DTOs;

public class DashboardSummaryDto
{
    public int TotalBills { get; set; }
    public int TotalPatients { get; set; }
    public int TotalDoctors { get; set; }
    public int TotalAppointments { get; set; }
    public decimal TotalRevenue { get; set; }
}
