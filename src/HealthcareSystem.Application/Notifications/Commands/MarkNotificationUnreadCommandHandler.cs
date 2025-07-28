using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Notifications.Commands;

public class MarkNotificationUnreadCommandHandler : IRequestHandler<MarkNotificationUnreadCommand, bool>
{
    private readonly INotificationService _notificationService;
    public MarkNotificationUnreadCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    public async Task<bool> Handle(MarkNotificationUnreadCommand request, CancellationToken cancellationToken)
    {
        return await _notificationService.MarkUnreadAsync(request.NotificationId);
    }
}
