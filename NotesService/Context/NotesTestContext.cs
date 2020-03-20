using notes_service.Context;
using notes_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Context
{
    public class NotesTestContext : INotesContext
    {

        private List<Note> Notes;

        public NotesTestContext()
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
            return Notes.Find(note => note.ID == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes;
        }

        public bool Update(Note note)
        {
            return Notes.Find(toFind => toFind.ID == note.ID) != null;

        }
    }
}
