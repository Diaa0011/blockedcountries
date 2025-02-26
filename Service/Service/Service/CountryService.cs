using System.Collections;
using BlockedCountries.Services.Repository.IRepository;
using Entities;

namespace BlockedCountries.Services.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo ??
                throw new ArgumentNullException(nameof(countryRepo));
        }
        public Country GetCountry(string code)
        {
            var country = _countryRepo.GetCountry(code);
            if (country == null)
            {
                throw new InvalidOperationException("The country does not exist.");
            }

            return country;
        }
        public IEnumerable<Country> GetCountries()
        {
            if (_countryRepo == null)
            {
                throw new InvalidOperationException("The country repository is not initialized.");
            }

            var countries = _countryRepo.GetCountries();
            
            return countries;
        }
        public void AddCountry(string code, bool? isBlocked)
        {
            var countries = _countryRepo.GetCountries();
            if (countries.Any(c => c.Code == code))
            {
                throw new InvalidOperationException("The country already exists.");
            }
            _countryRepo.AddCountry(code, isBlocked);
        }
    }
}