using BIED.Messaging.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.DAL.Service;
using NotesService.Domain.Models;
using NotesService.Messaging.Messages;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(Note note)
        {
            var created = service.Add(note);

            var message = new NoteCreatedMessage(created);

            await messageProducer.SendAsync(message, "notes.created");

            return Created($"/api/notes/{created.Id}", created);
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
            var idClaim = User.FindFirst("id");

            if (idClaim == null)
            {
                return Unauthorized();
            }

            return Ok(service.GetAll(idClaim.Value));
        }

        [HttpPut("/api/notes/{id}")]
        public IActionResult Update(Note note)
        {
            return Ok(service.Update(note.Id, note));
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