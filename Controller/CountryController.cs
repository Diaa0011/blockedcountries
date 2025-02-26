using BlockedCountries.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlockedCountries.Controller{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController:ControllerBase{
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService ?? 
                throw new ArgumentNullException(nameof(countryService));
        }
        [HttpGet("id/{code}")]
        public IActionResult GetCountryByCode(string code){
            var country = _countryService.GetCountry(code);
            return Ok(country);
        }
        [HttpGet]
        public IActionResult GetCountries(){
            var countries = _countryService.GetCountries();
            return Ok(countries);
        }
        [HttpPost]
        public IActionResult AddCountry(string code, bool? isBlocked){
            _countryService.AddCountry(code, isBlocked);

            return CreatedAtAction(nameof(GetCountryByCode), new { code = code }, code);
        }
    }
}