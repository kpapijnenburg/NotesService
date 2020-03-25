using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Net.Mime;
using System.Net;
using System.Net.Http;

namespace NotesService.IntegrationTests
{
    public class NotesControllerTests : IClassFixture<NotesServiceFactory>
    {
        private readonly HttpClient client;

        public NotesServiceFactory Factory { get; }

        public NotesControllerTests(NotesServiceFactory factory)
        {
            this.Factory = factory;
            this.client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ANoteExists_Returns200OK()
        {
            var response = await client.GetAsync("/notes");

            Assert.Equal(200, (int)response.StatusCode);
        }

        [Fact]
        public async Task Get_ANoteExists_ReturnJson()
        {
            var response = await client.GetAsync("/notes");

            Assert.Equal(MediaTypeNames.Application.Json, response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async Task GetById_NoteDoesNotExist_ReturnsNotFound()
        {
            var response = await client.GetAsync("/notes/100");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetById_NoteDoesExist_ReturnsOK()
        {
            var response = await client.GetAsync("/notes/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
