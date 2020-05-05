using NotesService.Domain;
using System;

namespace NotesService.Domain.Models
{
    public class Note : BaseEntity
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public int HandwrittenTextId { get; set; }
        public HandwrittenText HandwrittenText { get; set; }

        public Note(int iD, string content, HandwrittenText handwrittenText, DateTime created)
        {
            Content = content;
            HandwrittenText = handwrittenText;
        }
        public Note()
        {
            
        }
    }
}