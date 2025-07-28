using MediatR;

namespace HealthcareSystem.Application.Notifications.Commands;

public class SendSmsNotificationCommand : IRequest<bool>
{
    public string To { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
