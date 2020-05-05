using BIED.Messaging.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NotesService.DAL.Service;
using NotesService.Domain.Models;
using NotesService.Messaging.Messages;

namespace notes_service.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService service;
        private readonly IMessageProducer messageProducer;

        public NotesController(INotesService service, IMessageProducer messageProducer)
        {
            this.service = service;
            this.messageProducer = messageProducer;
        }

        [HttpPost("/api/notes")]
        public IActionResult Create(Note note)
        {
            var created = service.Add(note);

            var message = new NoteCreatedMessage(created);
            
        }


        [HttpGet("/api/notes/{id}")]
        public IActionResult GetById(int id)
        {
            var note = service.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpGet("/api/notes")]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpPut("/api/notes/{id}")]
        public IActionResult Update(Note note)
        {
            return Ok(service.Update(1, note));
        }

        [HttpDelete("/api/notes/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = service.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}