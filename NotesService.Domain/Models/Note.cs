using System;

namespace notes_service.Domain.Models
{
    public class Note
    {

        public string Title { get; set; }
        public string Content { get; set; }
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