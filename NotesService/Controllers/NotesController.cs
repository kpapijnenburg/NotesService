using Microsoft.AspNetCore.Mvc;
using NotesService.DAL.Service;

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
            return Ok(service.GetAll());
        }
    }
}