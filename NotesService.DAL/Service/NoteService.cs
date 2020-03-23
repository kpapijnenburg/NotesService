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

        public Note Create(Note note)
        {
            throw new NotImplementedException();
        }

        public bool delete(Note note)
        {
            throw new NotImplementedException();
        }

        public Note Get(int id)
        {
            return context.Notes
                .Include(n => n.HandwrittenText)
                .FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return context.Notes
                .Include(n => n.HandwrittenText)
                .ToList();
        }

        public bool Update(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
