using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NotesService.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
