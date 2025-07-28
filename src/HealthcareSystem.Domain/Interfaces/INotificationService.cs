using HealthcareSystem.Domain.Entities;
using System.Threading.Tasks;

namespace HealthcareSystem.Domain.Interfaces;

public interface INotificationService
{
    Task<IEnumerable<Notification>> GetByUserAsync(Guid userId);
    Task<IEnumerable<Notification>> SearchAsync(string? type, string? status, Guid? userId);
    Task<bool> MarkReadAsync(Guid notificationId);
    Task<bool> MarkUnreadAsync(Guid notificationId);

    Task SendEmailAsync(string to, string subject, string body);
    Task SendSmsAsync(string to, string message);
}
