using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace quickstart.Tests
{
    [Collection("Integration Tests")]
    public class DefaultControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public DefaultControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetRoot_ReturnsSuccessAndStatusUp()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync("/");

            // assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<ResponseType>(await response.Content.ReadAsStringAsync(),
                                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.Equal("Up", responseObject?.Status);
        }

        private class ResponseType
        {
            public String Status { get; set; }
        }
    }
}
