namespace notes_service.Models
{
    public enum State
    {
        Finished, Pending, Error
    }
    public class HandwrittenText
    {
        public string Image { get; set; }
        public State state;

        public HandwrittenText(string image, State state)
        {
            Image = image;
            this.state = state;
        }
        public HandwrittenText()
        {

        }
    }
}