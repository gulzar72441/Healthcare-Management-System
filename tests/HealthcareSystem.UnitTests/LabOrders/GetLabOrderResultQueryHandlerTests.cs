using System;
using System.Threading;
using System.Threading.Tasks;
using HealthcareSystem.Application.LabOrders.Queries;
using HealthcareSystem.Domain.Entities;
using HealthcareSystem.Domain.Interfaces;
using Moq;
using Xunit;

namespace HealthcareSystem.UnitTests.LabOrders
{
    public class GetLabOrderResultQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsResult_WhenLabOrderExists()
        {
            // Arrange
            var labOrderId = Guid.NewGuid();
            var labOrder = new LabOrder { Id = labOrderId, Result = "Positive" };
            var repoMock = new Mock<ILabOrderRepository>();
            repoMock.Setup(r => r.GetByIdAsync(labOrderId)).ReturnsAsync(labOrder);
            var handler = new GetLabOrderResultQueryHandler(repoMock.Object);
            var query = new GetLabOrderResultQuery(labOrderId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal("Positive", result);
        }

        [Fact]
        public async Task Handle_ReturnsNoResult_WhenLabOrderDoesNotExist()
        {
            // Arrange
            var labOrderId = Guid.NewGuid();
            var repoMock = new Mock<ILabOrderRepository>();
            repoMock.Setup(r => r.GetByIdAsync(labOrderId)).ReturnsAsync((LabOrder)null);
            var handler = new GetLabOrderResultQueryHandler(repoMock.Object);
            var query = new GetLabOrderResultQuery(labOrderId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal("No result available.", result);
        }
    }
}
