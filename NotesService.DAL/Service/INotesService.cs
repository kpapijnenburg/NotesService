using System.Collections.Generic;
using notes_service.Domain.Models;

namespace notes_service.Context
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