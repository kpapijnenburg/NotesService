using NotesService.Domain;

namespace notes_service.Domain.Models
{
    public enum State
    {
        Finished, Pending, Error
    }
    public class HandwrittenText: BaseEntity
    {
        public byte[] Image { get; set; }
        public State state;

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public HandwrittenText(byte[] image, State state)
        {
            Image = image;
            this.state = state;
        }
        public HandwrittenText()
        {

        }
    }
}