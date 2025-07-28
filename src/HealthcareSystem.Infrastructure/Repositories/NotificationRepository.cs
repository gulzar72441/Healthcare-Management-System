using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using HealthcareSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly HealthcareDbContext _context;
    public NotificationRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notification>> GetByUserAsync(Guid userId)
    {
        return await _context.Notifications.Where(n => n.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Notification>> SearchAsync(string? type, string? status, Guid? userId)
    {
        var query = _context.Notifications.AsQueryable();
        if (!string.IsNullOrEmpty(type))
            query = query.Where(n => n.Type == type);
        if (!string.IsNullOrEmpty(status))
            query = query.Where(n => n.Status == status);
        if (userId.HasValue)
            query = query.Where(n => n.UserId == userId);
        return await query.ToListAsync();
    }

    public async Task AddAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> MarkReadAsync(Guid notificationId)
    {
        var notification = await _context.Notifications.FindAsync(notificationId);
        if (notification == null) return false;
        notification.Status = "Read";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> MarkUnreadAsync(Guid notificationId)
    {
        var notification = await _context.Notifications.FindAsync(notificationId);
        if (notification == null) return false;
        notification.Status = "Unread";
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        // Implementation for sending email
    }

    public async Task SendSmsAsync(string to, string message)
    {
        // Implementation for sending SMS
    }
}
