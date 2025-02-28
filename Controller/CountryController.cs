using BlockedCountries.Dtos;
using BlockedCountries.Service.Service.IService;
using BlockedCountries.Service.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountries.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        //private readonly unBlockTempService _unBlockTempService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService ??
                throw new ArgumentNullException(nameof(countryService));
            /*_unBlockTempService = unBlockTempService ??
                throw new ArgumentNullException(nameof(unBlockTempService));*/
        }
        [HttpGet("code/{code}")]
        public IActionResult GetCountryByCode(string code)
        {
            var country = _countryService.GetCountry(code);
            return Ok(country);
        }
        [HttpGet("blocked")]
        public IActionResult GetAllCountries(int pageNumber = 1, int pageSize = 10, string? searchString = null)
        {
            if(pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }
            var countries = _countryService.GetCountries( pageNumber, pageSize, searchString);
            return Ok(countries);
        }
       
        [HttpPost]
        public IActionResult AddCountry([FromBody]BlockEntry blockEntry)
        {
            try
            {
                _countryService.AddCountry(blockEntry.code, blockEntry.name,false, null);
                return CreatedAtAction(nameof(GetCountryByCode), new { code = blockEntry.code },
                         _countryService.GetCountry(blockEntry.code));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("temporal-block")]
        public IActionResult temporalBlock([FromBody]BlockEntry blockEntry)
        {
            try
            {
                _countryService.AddCountry(blockEntry.code, blockEntry.name, true, blockEntry.TemporalBlockTime);
                return CreatedAtAction(nameof(GetCountryByCode), new { code = blockEntry.code },
                         _countryService.GetCountry(blockEntry.code));
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpDelete("block/{code}")]
        public IActionResult RemoveCountry(string code)
        {
            try
            {
                _countryService.RemoveCountry(code);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}