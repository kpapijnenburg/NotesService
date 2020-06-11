using System;
using System.Collections.Generic;
using NotesService.Domain.Models;

namespace NotesService.DAL.Service
{
    public interface INotesService
    {
        Note GetById(int id);
        IEnumerable<Note> GetAll(string userId);
        Note Add(Note note);
        bool Update(int id, Note note);
        bool Delete(int id);

    }
}