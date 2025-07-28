using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HealthcareSystem.IntegrationTests.LabOrders
{
    public class LabOrderResultEndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public LabOrderResultEndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetResult_ReturnsOkOrNotFound()
        {
            // Arrange
            var labOrderId = Guid.NewGuid(); // Use a random GUID; in real test, seed data or mock
            var url = $"/api/laborders/{labOrderId}/result";

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
