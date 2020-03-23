using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using NotesService.Context;
using NotesService.DAL;
using NotesService.Domain.Models;
using NotesService.DTO;

namespace notes_service.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService service;

        public NotesController(INotesService service)
        {
            this.service = service;
        }

        [HttpGet("/notes/{id}")]
        public IActionResult Get(int id)
        {
            var note = service.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpGet("/notes")]
        public IActionResult GetAll()
        {
            var notes = service.GetAll();

            if (notes == null)
            {
                return NotFound();
            }

            return Ok(notes);
        }
    }
}