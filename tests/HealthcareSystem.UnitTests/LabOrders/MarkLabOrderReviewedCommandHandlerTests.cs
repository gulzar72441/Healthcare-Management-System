using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.LabOrders.Commands;
using HealthcareSystem.Domain.Interfaces;
using Moq;
using Xunit;

namespace HealthcareSystem.UnitTests.LabOrders
{
    public class MarkLabOrderReviewedCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsTrue_WhenReviewSucceeds()
        {
            // Arrange
            var labOrderId = Guid.NewGuid();
            var repoMock = new Mock<ILabOrderRepository>();
            repoMock.Setup(r => r.MarkReviewedAsync(labOrderId)).ReturnsAsync(true);
            var handler = new MarkLabOrderReviewedCommandHandler(repoMock.Object);
            var command = new MarkLabOrderReviewedCommand(labOrderId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_ReturnsFalse_WhenLabOrderNotFound()
        {
            // Arrange
            var labOrderId = Guid.NewGuid();
            var repoMock = new Mock<ILabOrderRepository>();
            repoMock.Setup(r => r.MarkReviewedAsync(labOrderId)).ReturnsAsync(false);
            var handler = new MarkLabOrderReviewedCommandHandler(repoMock.Object);
            var command = new MarkLabOrderReviewedCommand(labOrderId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}
