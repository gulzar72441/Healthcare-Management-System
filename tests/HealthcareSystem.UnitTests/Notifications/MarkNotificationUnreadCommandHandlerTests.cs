using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.Notifications.Commands;
using HealthcareSystem.Domain.Interfaces;
using Moq;
using Xunit;

namespace HealthcareSystem.UnitTests.Notifications
{
    public class MarkNotificationUnreadCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsTrue_WhenMarkUnreadSucceeds()
        {
            // Arrange
            var notificationId = Guid.NewGuid();
            var serviceMock = new Mock<INotificationService>();
            serviceMock.Setup(s => s.MarkUnreadAsync(notificationId)).ReturnsAsync(true);
            var handler = new MarkNotificationUnreadCommandHandler(serviceMock.Object);
            var command = new MarkNotificationUnreadCommand(notificationId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_ReturnsFalse_WhenNotificationNotFound()
        {
            // Arrange
            var notificationId = Guid.NewGuid();
            var serviceMock = new Mock<INotificationService>();
            serviceMock.Setup(s => s.MarkUnreadAsync(notificationId)).ReturnsAsync(false);
            var handler = new MarkNotificationUnreadCommandHandler(serviceMock.Object);
            var command = new MarkNotificationUnreadCommand(notificationId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}
