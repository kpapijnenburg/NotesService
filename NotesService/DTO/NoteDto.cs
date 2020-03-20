using notes_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.DTO
{
    public class NoteDto
    {
        public string Title { get; set; }

        public Note ToObject()
        {
            return new Note()
            {
                Title = Title
            };
        }
    }
}
