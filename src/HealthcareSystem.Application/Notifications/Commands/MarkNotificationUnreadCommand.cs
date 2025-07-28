using MediatR;
using System;

namespace HealthcareSystem.Application.Notifications.Commands;

public class MarkNotificationUnreadCommand : IRequest<bool>
{
    public Guid NotificationId { get; }
    public MarkNotificationUnreadCommand(Guid notificationId) => NotificationId = notificationId;
}
