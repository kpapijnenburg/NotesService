using notes_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.DTO
{
    public class NoteDto
    {
        public string Content { get; set; }

        public Note ToObject()
        {
            return new Note()
            {
                Content = Content,
                Created = DateTime.Now,
                ID = 0,
                HandwrittenText = new HandwrittenText()
                {
                    Image = "https://images/image/png",
                    state = State.Pending
                }
            };
        }
    }
}
