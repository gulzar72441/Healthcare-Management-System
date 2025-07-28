namespace HealthcareSystem.Domain.Interfaces;

using HealthcareSystem.Domain.Entities;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetByUserAsync(Guid userId);
    Task<IEnumerable<Notification>> SearchAsync(string? type, string? status, Guid? userId);
    Task AddAsync(Notification notification);
    Task<bool> MarkReadAsync(Guid notificationId);
    Task<bool> MarkUnreadAsync(Guid notificationId);
}
