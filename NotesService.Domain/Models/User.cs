using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}
