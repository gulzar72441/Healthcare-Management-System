using HealthcareSystem.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace HealthcareSystem.Application.Notifications.Queries;

public class SearchNotificationsQuery : IRequest<IEnumerable<NotificationDto>>
{
    public string? Type { get; set; }
    public string? Status { get; set; }
    public Guid? UserId { get; set; }
    public SearchNotificationsQuery(string? type, string? status, Guid? userId)
    {
        Type = type;
        Status = status;
        UserId = userId;
    }
}
