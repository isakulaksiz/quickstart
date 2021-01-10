using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace quickstart.Controllers
{
    [ApiController]
    [Route("")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Up" };
            _logger.LogInformation($"Status pinged: {responseObject.Status}");
            return responseObject;
        }
    }
}
