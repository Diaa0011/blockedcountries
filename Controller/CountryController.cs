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
        private readonly ILogger<ICountryService> _logger;


        public CountryController(ICountryService countryService, ILogger<ICountryService> logger)
        {
            _countryService = countryService ??
                throw new ArgumentNullException(nameof(countryService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        [HttpGet("code/{code}")]
        public IActionResult GetCountryByCode(string code)
        {
            try
            {
                _logger.LogInformation("Getting country by code: {code}", code);

                var country = _countryService.GetCountry(code);
                
                return Ok(country);
            }catch(InvalidOperationException ex)
            {
                _logger.LogError(ex, "An error occurred while Fetching Country.");
                return NotFound(ex.Message);
            }

        }
        [HttpGet("blocked")]
        public IActionResult GetAllCountries([FromBody] PaginationEntry paginationEntry)
        {
            try
            {
                if (paginationEntry.PageNumber < 1 || paginationEntry.PageSize < 1)
                {
                    return BadRequest("Page number and page size must be greater than 0.");
                }
                var countries = _countryService.GetCountries(paginationEntry.PageNumber, paginationEntry.PageSize, paginationEntry.searchString);
                return Ok(countries);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "An error occurred while Fetching Countries.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("block")]
        public IActionResult AddCountry([FromBody] BlockEntry blockEntry)
        {
            try
            {
                _countryService.AddCountry(blockEntry.code, blockEntry.name, false, null);
                return CreatedAtAction(nameof(GetCountryByCode), new { code = blockEntry.code },
                         _countryService.GetCountry(blockEntry.code));
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost("temporal-block")]
        public IActionResult temporalBlock([FromBody] BlockEntry blockEntry)
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
                return NotFound(ex.Message);
            }
        }

    }
}