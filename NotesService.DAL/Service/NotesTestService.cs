using NotesService.Domain.Models;
using System;
using System.Collections.Generic;

namespace NotesService.DAL.Service
{
    public class NotesTestService : INotesService
    {

        private List<Note> Notes;

        public NotesTestService()
        {
            this.Notes = new List<Note>()
            {
                new Note() {Id = 1, Title = "Test notitie", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
            };
        }

        public Note Add(Note note)
        {
            Notes.Add(note);
            return note;
        }

        public bool Delete(int id)
        {
            var note = Notes.Find(note => note.Id == id);

            if (note == null)
            {
                return false;
            }

            Notes.Remove(note);
            return true;
        }

        public Note GetById(int id)
        {
            return Notes.Find(note => note.Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes;
        }

        public bool Update(int id, Note note)
        {
            return Notes.Find(toFind => toFind.Id == note.Id) != null;
        }
    }
}
