using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DistributedLogging.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class FileLoggingController : ControllerBase
    {
        private readonly ILogger<FileLoggingController> _logger;

        public FileLoggingController(ILogger<FileLoggingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Ping")]
        public ActionResult<string> PingTest()
        {
            _logger.LogInformation("Ping Method Triggered");
            _logger.LogError("Test Error Log");
            return Ok("Pong");
        }
    }
}
