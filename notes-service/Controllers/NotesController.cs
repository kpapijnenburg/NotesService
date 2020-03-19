using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using notes_service.Config;

namespace notes_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private IOptions<NotesConfig> config;

        public NotesController(IOptions<NotesConfig> config)
        {
            this.config = config;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>()
        {
            "hallo", "dit", "is", "een", "test"
        };
        }

        [HttpGet("/test")]
        public object Test()
        {
            return  config.Value.TestValue;
        }
    }
}