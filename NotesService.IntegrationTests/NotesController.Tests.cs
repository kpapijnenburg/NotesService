using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Net.Mime;
using System.Net;
using System.Net.Http;
using NotesService.Domain.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace NotesService.IntegrationTests
{
    public class NotesControllerTests : IClassFixture<NotesServiceFactory>
    {
        private readonly HttpClient client;
        private Note DefaultNote { get; set; }
        public NotesServiceFactory Factory { get; }

        public NotesControllerTests()
        {
            this.Factory =  new NotesServiceFactory();
            this.client = Factory.CreateClient();

            this.DefaultNote = new Note()
            {
                Title = "Test Note",
                Content = "",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                HandwrittenText = new HandwrittenText()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            };
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

        [Fact]
        public async Task Create_NoteHaseBeenCreated_ReturnsOK()
        {
            // Arrange
            string json = JsonConvert.SerializeObject(DefaultNote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/notes", content);


            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Create_NoteCannotBeDeserialized_ReturnsBadRequest()
        {
            // Arrange
            var note = "BadRequest";

            string json = JsonConvert.SerializeObject(note);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/notes", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Update_NoteExists_ReturnsOK()
        {
            // Arrange
            DefaultNote.Id = 1;
            string json = JsonConvert.SerializeObject(DefaultNote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/notes/1", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_NoteDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            int noteId = 2;

            // Act
            var response = await client.DeleteAsync($"/notes/{noteId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_NoteDoesExist_ReturnsNoContent()
        {
            // Arrange
            int noteId = 1;

            // Act
            var response = await client.DeleteAsync($"/notes/{noteId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
