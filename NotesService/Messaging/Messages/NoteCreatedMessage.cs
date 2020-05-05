using NotesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Messaging.Messages
{
    public class NoteCreatedMessage
    {
       public NoteCreatedMessage(Note note)
        {
            NoteId = note.Id;
        }

        public int NoteId { get; set; }
        public byte[] Image { get; set; }
    }
}
