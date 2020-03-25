using Microsoft.EntityFrameworkCore;
using NotesService.DAL;
using NotesService.DAL.Service;
using NotesService.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NotesService.Tests
{
    public class NoteServiceTests
    {
        public DbContextOptions<NotesContext> Initialize(string arg)
        {
            // Sets up a new in memory database with the given name. 
            // The database is deleted when the options object goes out of scope.
            return new DbContextOptionsBuilder<NotesContext>()
                .UseInMemoryDatabase(arg)
                .Options;
        }

        [TestCase("Create_WritesToDB_EntriesPersist")]
        public void Create_WritesToDB_EntriesPersist(string DbName)
        {
            // Arrange
            var options = Initialize(DbName);
            int noteId = 0;
            // Act
            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                noteId = service.Add(new Note() { Title = "Test note", HandwrittenText = new HandwrittenText() { Image = new byte[8] } }).Id;
            }

            // Assert
            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                var note = service.GetById(noteId);

                Assert.AreEqual(noteId, note.Id);
                Assert.AreEqual("Test note", note.Title);
            }
        }

        [TestCase("Create_WritesToDB_HandwrittenTextStateIsPending")]
        public void Create_WritesToDB_HandwrittenTextStateIsPending(string DbName)
        {
            // Arrange
            var options = Initialize(DbName);
            int noteId = 0;
            // Act
            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                noteId = service.Add(new Note() { Title = "Test note", HandwrittenText = new HandwrittenText() { Image = new byte[8] } }).Id;
            }

            // Assert
            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                var note = service.GetById(noteId);

                Assert.AreEqual(State.Pending, note.HandwrittenText.State);
            }
        }

        [TestCase("GetAll_HasEntries_ReturnsListOfNotes")]
        public void GetAll_HasEntries_ReturnsListOfNotes(string DbName)
        {
            // Arrange
            var options = Initialize(DbName);

            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                service.Add(new Note() { Title = "Test note", HandwrittenText = new HandwrittenText() { Image = new byte[8] } });
            }

            // Act
            var result = new List<Note>();

            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                result = service.GetAll() as List<Note>;
            }

            // Assert
            Assert.IsInstanceOf<List<Note>>(result);
            Assert.IsNotEmpty(result);
        }

        [TestCase("GetById_EntryDoesNotExist_ReturnsNull")]
        public void GetById_EntryDoesNotExist_ReturnsNull(string DbName)
        {
            // Arrange
            var options = Initialize(DbName);
            using var context = new NotesContext(options);

            // Act
            var service = new NoteService(context);
            var result = service.GetById(1);

            // Assert
            Assert.IsNull(result);
        }

        [TestCase("GetById_EntryDoesExist_ReturnsNote")]
        public void GetById_EntryDoesExist_ReturnsNote(string DbName)
        {
            // Arrange
            var options = Initialize(DbName);
            var note = new Note() { Title = "Test Note" };

            // Act
            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                note = service.Add(note);
            }

            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                var noteFromDb = service.GetById(note.Id);

                //Assert
                Assert.NotNull(noteFromDb);
                Assert.IsInstanceOf<Note>(noteFromDb);
            }
        }

        [TestCase("Update_EntityDoesNotExist_ReturnsTrueAndCreatesEntity")]
        public void Update_EntityDoesNotExist_ReturnsTrueAndCreatesEntity(string DbName)
        {
            // Arrange 
            var options = Initialize(DbName);
            var id = 1;
            var note = new Note() { Title = "Test Note" };

            // Act
            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                var result = service.Update(1, note);

                // Assert
                Assert.False(result);
            }

            using (var context = new NotesContext(options))
            {
                var service = new NoteService(context);
                var fromDb = service.GetById(id);

                // Assert
                Assert.NotNull(fromDb);
            }
        }
    }
}
