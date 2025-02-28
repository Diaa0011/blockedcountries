using BlockedCountries.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountries.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController:ControllerBase
    {
        private readonly ILogService _logService;
        public LogsController(ILogService logService)
        {
            _logService = logService ??
                throw new ArgumentNullException(nameof(logService));
        }   
        [HttpGet("logs")]
        public IActionResult GetLogs(int pageNumber=1,int pageSize=250)
        {
            var logs = _logService.GetLogs(pageNumber, pageSize);
            return Ok(logs.Result);
        }
    }
}