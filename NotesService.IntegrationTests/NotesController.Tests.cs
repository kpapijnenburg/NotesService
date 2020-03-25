using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Net.Mime;
using System.Net;

namespace NotesService.IntegrationTests
{
    //TODO: Gaat toevallig goed. 
    public class NotesControllerTests : IClassFixture<NotesServiceFactory>
    {
        private readonly NotesServiceFactory factory;

        public NotesControllerTests(NotesServiceFactory factory)
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
        public async Task Get()
        {
            var client = factory.CreateClient();

            var response = await client.GetAsync("/notes/100");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
