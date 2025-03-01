using BlockedCountries.Dtos;
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
        public IActionResult GetLogs([FromBody]BlockedLogsPaginationEngry paginationEntry)
        {
            var logs = _logService.GetLogs(paginationEntry.PageNumber, paginationEntry.PageSize);
            return Ok(logs.Result);
        }
    }
}