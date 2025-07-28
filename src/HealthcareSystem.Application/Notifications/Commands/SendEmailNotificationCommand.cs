using MediatR;

namespace HealthcareSystem.Application.Notifications.Commands;

public class SendEmailNotificationCommand : IRequest<bool>
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}
