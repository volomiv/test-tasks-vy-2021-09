using System;
using Forbytes.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace Forbytes.MovieCatalog.API.Controllers
{
    [Route("")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IApplication _application;

        public PingController(IApplication application)
        {
            _application = application;
        }

        [HttpGet("")]
        public string Ping()
        {
            return $"{_application.Name} - OK - {DateTime.UtcNow:O}";
        }
    }
}