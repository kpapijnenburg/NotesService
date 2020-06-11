using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NotesService.Domain
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}
