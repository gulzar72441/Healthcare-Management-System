using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HealthcareSystem.IntegrationTests.Appointments
{
    public class AppointmentCancelEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public AppointmentCancelEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Cancel_ReturnsNoContentOrNotFound()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();
            var url = $"/api/appointments/{appointmentId}/cancel";

            // Act
            var response = await _client.PostAsync(url, null);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
