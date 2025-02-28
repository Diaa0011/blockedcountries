using System.Collections.Concurrent;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Repository.IRepository;

namespace BlockedCountries.Service.Repository.Repository
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
        public bool CountryExists(string code)
        {
            if (_countries.ContainsKey(code))
            {
                return true;
            }
            return false;
        }
        public IEnumerable<Country> GetCountries()
        {
            var countries = _countries.Values;
            return countries;
        }

        public void AddCountry(string code, string? name, bool temporalBlocked = false, int? TemporalBlockTime = null)
        {

            _countries.TryAdd(code, new Country { Code = code, Name = name,
            temporalBlocked = temporalBlocked, TemporalBlockTime = TemporalBlockTime });
        }
        public void RemoveCountry(string code)
        {
            _countries.TryRemove(code, out _);
        }


        private void SeedCountries()
        {
            _countries.TryAdd("US", new Country { Code = "US", Name = "United States",
                temporalBlocked = false, TemporalBlockTime = null });
        }
    }
}