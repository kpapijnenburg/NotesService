using Microsoft.AspNetCore.Mvc;
using Moq;
using notes_service.Controllers;
using NotesService.Context;
using NotesService.Domain.Models;
using NUnit.Framework;

namespace NotesService.Tests
{
    public class NotesControllerTests
    {
        private Mock<INotesService> contextMock;
        private NotesController controller;

        [SetUp]
        public void SetUp()
        {
            contextMock = new Mock<INotesService>();
            controller = new NotesController(contextMock.Object);
        }

        [Test]
        public void Get_NoteWithGivenIdExists_Returns200OK()
        {
            var note = new Note();

            contextMock.Setup(c => c.Get(It.IsAny<int>())).Returns(note);

            var result = controller.Get(1);
            var anus = result as OkObjectResult;

            Assert.AreEqual(note, result);
        }
    }
}
