using NotesService.Context;
using NotesService.Domain.Models;
using System;
using System.Collections.Generic;

namespace NotesService.IntegrationTests
{
    public class DummyNotesContext : INotesService
    {
        private List<Note> Notes;

        public DummyNotesContext()
        {
            this.Notes = new List<Note>()
            {
                new Note(1, "Test notitie", null, DateTime.Now)
            };
        }

        public Note Create(Note note)
        {
            Notes.Add(note);
            return note;
        }

        public bool delete(Note note)
        {
            return Notes.Remove(note);
        }

        public Note Get(int id)
        {
            return Notes.Find(note => note.Id == id);
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
