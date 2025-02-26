using BlockedCountries.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountries.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService ??
                throw new ArgumentNullException(nameof(countryService));
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
        public IActionResult AddCountry(string code, string? name)
        {
            try
            {
                _countryService.AddCountry(code, name);
                return CreatedAtAction(nameof(GetCountryByCode), new { code = code },
                         _countryService.GetCountry(code));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
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