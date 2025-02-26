using System.Collections.Concurrent;
using BlockedCountries.Services.Repository.IRepository;
using Entities;

namespace BlockedCountries.Services.Repository.Repository
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ConcurrentDictionary<string, Country> _countries = 
                new ConcurrentDictionary<string, Country>();
        public CountryRepo()
        {
            SeedCountries();
        }
        public Country GetCountry(string code)
        {

            return _countries[code];

        }
        public IEnumerable<Country> GetCountries()
        {
            var countries =  (IEnumerable<Country>) _countries.Values;
            return countries;
        }

        public void AddCountry(string code, bool? isBlocked)
        {
            if (_countries.ContainsKey(code))
            {
                throw new InvalidOperationException("The country already exists.");
            }
            if(isBlocked == null || isBlocked == false)
            {
                _countries.TryAdd(code, new Country { Code = code, IsBlocked = false });
            }else{
                _countries.TryAdd(code, new Country { Code = code, IsBlocked = true });
            }
           
        }


        private void SeedCountries()
        {
            _countries.TryAdd("US", new Country { Code = "US", IsBlocked = false });
            _countries.TryAdd("EG", new Country { Code = "EG", IsBlocked = true });
            _countries.TryAdd("DE", new Country { Code = "DE", IsBlocked = false });
            _countries.TryAdd("IN", new Country { Code = "IN", IsBlocked = false });
            _countries.TryAdd("GB", new Country { Code = "GB", IsBlocked = true });
        }
    }
}