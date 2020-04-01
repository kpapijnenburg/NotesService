using NotesService.Domain;

namespace NotesService.Domain.Models
{
    public enum State
    {
        Finished, Pending, Error
    }
    public class HandwrittenText: BaseEntity
    {
        public byte[] Image { get; set; }
        public State State { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }

        public HandwrittenText(byte[] image, State state)
        {
            Image = image;
            this.State = state;
        }
        public HandwrittenText()
        {

        }
    }
}