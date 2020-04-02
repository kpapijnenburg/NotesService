using Microsoft.AspNetCore.Mvc;
using NotesService.DAL.Service;
using NotesService.Domain.Models;

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

        [HttpPost("/api/notes")]
        public IActionResult Create(Note note)
        {
            return Ok(service.Add(note));
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