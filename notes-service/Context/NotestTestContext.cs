using System;
using System.Collections.Generic;
using notes_service.Models;

namespace notes_service.Context
{
    public class NotesTestContext : INotesContext
    {

        private List<Note> Notes;

        public NotesTestContext()
        {
            Notes = new List<Note>()
            {
                new Note(1, "Dit is een test notitie", null, DateTime.Now)
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes;
        }

        public bool Update(Note note)
        {
            throw new System.NotImplementedException();
        }
    }
}