namespace notes_service.Models
{
    public enum State
    {
        Finished, Pending, Error
    }
    public class HandwrittenText
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