using NotesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NotesService.DAL.Service
{
    public class NoteService : INotesService
    {
        private readonly NotesContext context;

        public NoteService(NotesContext context)
        {
            this.context = context;
        }

        public Note Add(Note note)
        {
            var entry = context.Add(note);
            context.SaveChanges();

            return entry.Entity;
        }

        public bool Delete(int id)
        {
            var note = context.Notes
                .FirstOrDefault(note => note.Id == id);

            if (note == null) return false;

            context.Remove(note);
            context.SaveChanges();

            return true;
        }

        public Note GetById(int id)
        {
            var note = context.Notes
                .Include(n => n.HandwrittenText)
                .FirstOrDefault(n => n.Id == id);
            return note;
        }

        public IEnumerable<Note> GetAll()
        {
            return context.Notes
                .Include(n => n.HandwrittenText)
                .ToList();
        }

        public bool Update(int id, Note toUpdate)
        {
            var fromDb = context.Notes.FirstOrDefault(note => note.Id == id);

            if (fromDb == null)
            {
                context.Add(toUpdate);
                context.SaveChanges();
                return false;
            }

            fromDb.Title = toUpdate.Title;
            fromDb.HandwrittenText = toUpdate.HandwrittenText;

            context.SaveChanges();
            return true;
        }
    }
}
