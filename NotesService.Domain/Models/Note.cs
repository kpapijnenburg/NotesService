using NotesService.Domain;
using System;
using System.Runtime.Serialization;

namespace NotesService.Domain.Models
{
    [DataContract]
    public class Note : BaseEntity
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public byte[] ImageData { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}