using MediatR;
using System;

namespace HealthcareSystem.Application.Notifications.Commands;

public class MarkNotificationReadCommand : IRequest<bool>
{
    public Guid NotificationId { get; }
    public MarkNotificationReadCommand(Guid notificationId) => NotificationId = notificationId;
}
