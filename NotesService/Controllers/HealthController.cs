using Microsoft.AspNetCore.Mvc;
using NotesService.DAL.Service;
using NotesService.Domain.Models;

namespace notes_service.Controllers
{
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("/api/healthcheck")]
        public IActionResult HealthCheck()
        {
            return Ok();
        }
    }
}