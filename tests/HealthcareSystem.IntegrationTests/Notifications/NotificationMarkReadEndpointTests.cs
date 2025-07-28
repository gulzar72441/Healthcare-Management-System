using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HealthcareSystem.IntegrationTests.Notifications
{
    public class NotificationMarkReadEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public NotificationMarkReadEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task MarkRead_ReturnsNoContentOrNotFound()
        {
            // Arrange
            var notificationId = Guid.NewGuid();
            var url = $"/api/notifications/{notificationId}/mark-read";

            // Act
            var response = await _client.PostAsync(url, null);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
