using MediatR;
using HealthcareSystem.Domain.Interfaces;

namespace HealthcareSystem.Application.Notifications.Commands;

public class SendEmailNotificationCommandHandler : IRequestHandler<SendEmailNotificationCommand, bool>
{
    private readonly INotificationService _notificationService;
    public SendEmailNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<bool> Handle(SendEmailNotificationCommand request, CancellationToken cancellationToken)
    {
        await _notificationService.SendEmailAsync(request.To, request.Subject, request.Body);
        return true;
    }
} 