using System.Collections;
using Entities;

namespace BlockedCountries.Services.Service
{
    public interface ICountryService
    {
        //Task<string> GetCountryCode(string ip);
        Country GetCountry(string code);
        IEnumerable<Country> GetCountries();
        void AddCountry(string code, bool? isBlocked);
    }
}