using NotesService.Domain;

namespace NotesService.Domain.Models
{
    public class HandwrittenText: BaseEntity
    {
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}