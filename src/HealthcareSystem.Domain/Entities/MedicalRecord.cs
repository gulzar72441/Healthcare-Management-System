namespace HealthcareSystem.Domain.Entities;

public class MedicalRecord
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string History { get; set; } = string.Empty;
    public string Treatments { get; set; } = string.Empty;
    public ICollection<MedicalFile> Files { get; set; } = new List<MedicalFile>();
}
