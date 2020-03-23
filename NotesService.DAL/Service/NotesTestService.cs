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
                new Note() {Id = 1, Title = "Test notitie", Content = "Test Content", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now}
            };
        }

        public Note Create(Note note)
        {
            Notes.Add(note);
            return note;
        }

        public bool Delete(Note note)
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
