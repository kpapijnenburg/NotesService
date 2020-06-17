using NotesService.Domain;
using System;
using System.Runtime.Serialization;

namespace NotesService.Domain.Models
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public byte[] ImageData { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}