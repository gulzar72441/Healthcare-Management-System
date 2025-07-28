using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareSystem.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<Notification>> GetByUserAsync(Guid userId)
        {
            return await _notificationRepository.GetByUserAsync(userId);
        }

        public async Task<IEnumerable<Notification>> SearchAsync(string? type, string? status, Guid? userId)
        {
            return await _notificationRepository.SearchAsync(type, status, userId);
        }

        public async Task<bool> MarkReadAsync(Guid notificationId)
        {
            // You may want to add logging or additional logic here
            return await _notificationRepository.MarkReadAsync(notificationId);
        }

        public async Task<bool> MarkUnreadAsync(Guid notificationId)
        {
            return await _notificationRepository.MarkUnreadAsync(notificationId);
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            // TODO: Integrate with a real email service
            await Task.CompletedTask;
        }

        public async Task SendSmsAsync(string to, string message)
        {
            // TODO: Integrate with a real SMS service
            await Task.CompletedTask;
        }
    }
}
