using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotesService.Domain.Models
{
    public class User
    {
        [Key]
        public int Key { get; set; }
        public Guid Id { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}
