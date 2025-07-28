using HealthcareSystem.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Notifications.Queries;

public class GetNotificationsByUserQuery : IRequest<IEnumerable<NotificationDto>>
{
    public Guid UserId { get; set; }
    public GetNotificationsByUserQuery(Guid userId)
    {
        UserId = userId;
    }
}
