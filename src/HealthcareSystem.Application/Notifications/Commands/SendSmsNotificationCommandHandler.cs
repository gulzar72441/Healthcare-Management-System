using MediatR;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Notifications.Commands;

public class SendSmsNotificationCommandHandler : IRequestHandler<SendSmsNotificationCommand, bool>
{
    private readonly INotificationService _notificationService;
    public SendSmsNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<bool> Handle(SendSmsNotificationCommand request, CancellationToken cancellationToken)
    {
        await _notificationService.SendSmsAsync(request.To, request.Message);
        return true;
    }
} 