using System.Collections.Generic;
using NotesService.Domain.Models;

namespace NotesService.DAL.Service
{
    public interface INotesService
    {
        Note Get(int id);
        IEnumerable<Note> GetAll();
        Note Create(Note note);
        bool Update(Note note);
        bool Delete(Note note);

    }
}