﻿using notes_service.Context;
using notes_service.Models;
using System;
using System.Collections.Generic;

namespace NotesService.IntegrationTests
{
    public class DummyNotesContext : INotesContext
    {
        private List<Note> Notes;

        public DummyNotesContext()
        {
            this.Notes = new List<Note>()
            {
                new Note(1, "Test notitie", null, DateTime.Now)
            };
        }

        public Note Create(Note note)
        {
            Notes.Add(note);
            return note;
        }

        public bool delete(Note note)
        {
            return Notes.Remove(note);
        }

        public Note Get(int id)
        {
            return Notes.Find(note => note.ID == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return Notes;
        }

        public bool Update(Note note)
        {
            return Notes.Find(toFind => toFind.ID == note.ID) != null;

        }
    }
}
