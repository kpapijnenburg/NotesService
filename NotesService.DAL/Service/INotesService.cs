using System.Collections.Generic;
using NotesService.Domain.Models;

namespace NotesService.DAL.Service
{
    public interface INotesService
    {
        Note GetById(int id);
        IEnumerable<Note> GetAll();
        Note Add(Note note);
        bool Update(Note note);
        bool Delete(Note note);

    }
}