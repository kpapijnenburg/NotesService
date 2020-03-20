using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using notes_service.Context;
using notes_service.Models;
using NotesService.DTO;

namespace notes_service.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INotesContext context;

        public NotesController(INotesContext context)
        {
            this.context = context;
        }

        [HttpGet("/notes/{id}")]
        public IActionResult Get(int id)
        {
            var note = context.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpGet("/notes")]
        public IActionResult GetAll()
        {
            var notes = context.GetAll();

            if (notes == null)
            {
                return NotFound();
            }

            return Ok(notes);
        }

        [HttpPost("/notes")]
        public IActionResult Create(string imageData)
        {
            var note = new Note()
            {
                HandwrittenText =
                {
                    Image = imageData,
                    state = State.Pending
                },
                Created = DateTime.Now
            };

            return Ok(note);
        }
    }
}