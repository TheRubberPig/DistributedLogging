using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedLogging.Controllers
{
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class DatabaseLoggingController : ControllerBase
    {
        private readonly ILogger<DatabaseLoggingController> _logger;

        public DatabaseLoggingController(ILogger<DatabaseLoggingController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Log Info Message")]
        public ActionResult<string> LogInfoMessage(string message)
        {
            _logger.LogInformation(message);
            return Ok(string.Format(CultureInfo.CurrentCulture, "Logged message: {0} to file", message));
        }

        [HttpPost("Log Debug Message")]
        public ActionResult<string> LogDebugMessage(string message)
        {
            _logger.LogDebug(message);
            return Ok(string.Format(CultureInfo.CurrentCulture, "Logged message: {0} to file", message));
        }

        [HttpPost("Log Warning Message")]
        public ActionResult<string> LogWarningMessage(string message)
        {
            _logger.LogWarning(message);
            return Ok(string.Format(CultureInfo.CurrentCulture, "Logged message: {0} to file", message));
        }

        [HttpPost("Log Error Message")]
        public ActionResult<string> LogErrorMessage(string message)
        {
            _logger.LogError(message);
            return Ok(string.Format(CultureInfo.CurrentCulture, "Logged message: {0} to file", message));
        }
    }
}
