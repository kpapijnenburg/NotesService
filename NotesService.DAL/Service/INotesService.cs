using System.Collections.Generic;
using NotesService.Domain.Models;

namespace NotesService.Context
{
    public interface INotesService
    {
        Note Get(int id);
        IEnumerable<Note> GetAll();
        Note Create(Note note);
        bool Update(Note note);
        bool delete(Note note);

    }
}