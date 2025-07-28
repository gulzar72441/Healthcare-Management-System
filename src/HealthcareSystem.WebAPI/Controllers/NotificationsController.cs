using HealthcareSystem.Application.Notifications.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthcareSystem.Application.DTOs;
using HealthcareSystem.Application.Notifications.Queries;

namespace HealthcareSystem.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("send-email")]
    public async Task<ActionResult> SendEmail([FromBody] SendEmailNotificationCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("send-sms")]
    public async Task<ActionResult> SendSms([FromBody] SendSmsNotificationCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetByUser(Guid userId)
    {
        var result = await _mediator.Send(new GetNotificationsByUserQuery(userId));
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> Search([FromQuery] string? type, [FromQuery] string? status, [FromQuery] Guid? userId)
    {
        var result = await _mediator.Send(new SearchNotificationsQuery(type, status, userId));
        return Ok(result);
    }

    [HttpPost("{notificationId}/mark-read")]
    public async Task<ActionResult> MarkRead(Guid notificationId)
    {
        var success = await _mediator.Send(new MarkNotificationReadCommand(notificationId));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPost("{notificationId}/mark-unread")]
    public async Task<ActionResult> MarkUnread(Guid notificationId)
    {
        var success = await _mediator.Send(new MarkNotificationUnreadCommand(notificationId));
        if (!success) return NotFound();
        return NoContent();
    }
}
