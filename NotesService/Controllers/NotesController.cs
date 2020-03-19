using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using notes_service.Context;
using notes_service.Models;


namespace notes_service.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INotesContext context;

        public NotesController()
        {
            context = new NotesTestContext();
        }

        [HttpGet("/notes/{id}")]
        public Note Get(int id)
        {
            return context.Get(id);
        }
    }
}