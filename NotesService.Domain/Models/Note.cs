using NotesService.Domain;
using System;

namespace NotesService.Domain.Models
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
    }
}