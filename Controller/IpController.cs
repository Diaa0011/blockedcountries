
using BlockedCountries.Service.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountries.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController:ControllerBase
    {
        private readonly IIpService _ipService;
        public IpController(IIpService ipService)
        {
            _ipService = ipService ??
                throw new ArgumentNullException(nameof(ipService));
        }
        //[HttpGet("{ip?}")] //This is the was original part used from query
        [HttpGet]
        public async Task<IActionResult> GetIpGeoData([FromQuery]string? ip)
        {
            var ipGeoData = await _ipService.GetIpGeoData(ip);
            return Ok(ipGeoData);
        }
    }
}