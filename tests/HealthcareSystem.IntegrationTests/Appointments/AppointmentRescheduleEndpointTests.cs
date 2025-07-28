using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HealthcareSystem.IntegrationTests.Appointments
{
    public class AppointmentRescheduleEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public AppointmentRescheduleEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Reschedule_ReturnsNoContentOrNotFound()
        {
            // Arrange
            var appointmentId = Guid.NewGuid();
            var url = $"/api/appointments/{appointmentId}/reschedule";
            var newDate = System.DateTime.UtcNow.AddDays(1);
            var content = new StringContent($"\"{newDate:O}\"", Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}
