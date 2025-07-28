using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Notifications.Queries;

public class SearchNotificationsQueryHandler : IRequestHandler<SearchNotificationsQuery, IEnumerable<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;
    public SearchNotificationsQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<IEnumerable<NotificationDto>> Handle(SearchNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository.SearchAsync(request.Type, request.Status, request.UserId);
        return notifications.Select(n => new NotificationDto
        {
            Id = n.Id,
            UserId = n.UserId,
            Type = n.Type,
            Status = n.Status,
            Message = n.Message,
            CreatedAt = n.CreatedAt
        });
    }
}
