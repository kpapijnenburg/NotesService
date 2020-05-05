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
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            };
        }

        public Note Add(Note note)
        {
            Notes.Add(note);
            return note;
        }

        public bool Delete(int id)
        {
            var note = Notes.FirstOrDefault(note => note.Id == id);

            if (note == null)
            {
                return false;
            }

            return true;
        }

        public Note GetById(int id)
        {
            return Notes.FirstOrDefault(note => note.Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes;
        }

        public bool Update(int id, Note toUpdate)
        {
            if (!Notes.Exists(toFind => toFind.Id == id))
            {
                Notes.Add(toUpdate);
                return false;
            }
            return true;
        }
    }
}
