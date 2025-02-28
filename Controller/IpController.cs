
using BlockedCountries.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountries.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController:ControllerBase
    {
        private readonly IIpService _ipService;
        private readonly ILogService _logService;
        public IpController(IIpService ipService,ILogService logService)
        {
            _ipService = ipService ??
                throw new ArgumentNullException(nameof(ipService));
            _logService = logService ??
                throw new ArgumentNullException(nameof(logService));
        }
        //[HttpGet("{ip?}")] //This is the was original depended on just anotation which made ip mandatory
        //The new part depends on anotation and query so the ip is not mandatory
        [HttpGet("lookup")]
        public async Task<IActionResult> GetIpGeoData([FromQuery]string? ip)
        {
            var ipGeoData = await _ipService.GetIpGeoData(ip);
            return Ok(ipGeoData);
        }
        //For external Ip don't forget
        [HttpGet("check-block")]
        public async Task<IActionResult> Checkblocked()
        {
            var isblocked_ip = await _ipService.CheckBlocked();
            _logService.AddLog(isblocked_ip.Item2, isblocked_ip.Item1);

            return Ok(isblocked_ip.Item1);
        }

    }
}