using Microsoft.AspNetCore.Mvc;
using Moq;
using notes_service.Controllers;
using NotesService.DAL.Service;
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
    }
}
