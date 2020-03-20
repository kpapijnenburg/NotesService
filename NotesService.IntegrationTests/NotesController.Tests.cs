using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Net.Mime;
using System.Net;

namespace NotesService.IntegrationTests
{
    public class NotesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public NotesControllerTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_ANoteExists_Returns200OK()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/notes");

            Assert.Equal(200, (int)response.StatusCode);
        }

        [Fact]
        public async Task Get_ANoteExists_ReturnJson()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/notes");

            Assert.Equal(MediaTypeNames.Application.Json, response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async Task Fuok()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/notes/100");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
