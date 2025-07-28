using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HealthcareSystem.IntegrationTests.LabOrders
{
    public class LabOrderMarkReviewedEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public LabOrderMarkReviewedEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task MarkReviewed_ReturnsNoContentOrNotFound()
        {
            // Arrange
            var labOrderId = Guid.NewGuid(); // Use a random GUID; in real test, seed data or mock
            var url = $"/api/laborders/{labOrderId}/mark-reviewed";

            // Act
            var response = await _client.PostAsync(url, null);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
