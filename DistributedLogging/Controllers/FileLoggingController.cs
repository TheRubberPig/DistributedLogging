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

        [HttpPost("Log Info Message")]
        public ActionResult<string> LogInfoMessage(string message)
        {
            _logger.LogInformation(message);
            return Ok(string.Format("Logged message: {0} to file", message));
        }

        [HttpPost("Log Debug Message")]
        public ActionResult<string> LogDebugMessage(string message)
        {
            _logger.LogDebug(message);
            return Ok(string.Format("Logged message: {0} to file", message));
        }

        [HttpPost("Log Warning Message")]
        public ActionResult<string> LogWarningMessage(string message)
        {
            _logger.LogWarning(message);
            return Ok(string.Format("Logged message: {0} to file", message));
        }

        [HttpPost("Log Error Message")]
        public ActionResult<string> LogErrorMessage(string message)
        {
            _logger.LogError(message);
            return Ok(string.Format("Logged message: {0} to file", message));
        }
    }
}
