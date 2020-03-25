using NotesService.DAL.Service;
using NotesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesService.IntegrationTests
{
    public class DummyNotesContext : INotesService
    {
        private readonly List<Note> Notes;

        public DummyNotesContext()
        {
            this.Notes = new List<Note>()
            {
                new Note() {
                    Id = 1,
                    Title = "Test Notitie",
                    Content = "",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    HandwrittenText = new HandwrittenText()
                    {
                        Id = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        State = State.Pending,
                        Image = new byte[8]
                    }
                }
            };
        }

        public Note Add(Note note)
        {
            Notes.Add(note);
            return note;
        }

        public bool Delete(Note note)
        {
            return Notes.Remove(note);
        }

        public Note GetById(int id)
        {
            return Notes.FirstOrDefault(note => note.Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes;
        }

        public bool Update(Note note)
        {
            return Notes.Find(toFind => toFind.Id == note.Id) != null;

        }
    }
}
