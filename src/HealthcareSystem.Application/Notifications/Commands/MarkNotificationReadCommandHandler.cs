using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Notifications.Commands;

public class MarkNotificationReadCommandHandler : IRequestHandler<MarkNotificationReadCommand, bool>
{
    private readonly INotificationService _notificationService;
    public MarkNotificationReadCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    public async Task<bool> Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
    {
        return await _notificationService.MarkReadAsync(request.NotificationId);
    }
}
