using System;

namespace notes_service.Models
{
    public class Note
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public HandwrittenText HandwrittenText { get; set; }

        public Note(int iD, string content, HandwrittenText handwrittenText, DateTime created)
        {
            Id = iD;
            Content = content;
            HandwrittenText = handwrittenText;
            Created = created;
        }
        public Note()
        {
            
        }
    }
}