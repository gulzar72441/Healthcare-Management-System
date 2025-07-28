using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Domain.Interfaces;
using MediatR;

namespace HealthcareSystem.Application.Notifications.Queries;

public class GetNotificationsByUserQueryHandler : IRequestHandler<GetNotificationsByUserQuery, IEnumerable<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;
    public GetNotificationsByUserQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<IEnumerable<NotificationDto>> Handle(GetNotificationsByUserQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository.GetByUserAsync(request.UserId);
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
