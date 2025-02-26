using System.Collections;
using BlockedCountries.Dtos;

namespace BlockedCountries.Services.Service
{
    public interface ICountryService
    {
        //Task<string> GetCountryCode(string ip);
        Country GetCountry(string code);
        IEnumerable<Country> GetCountries(int pageNumber,int pageSize,string? searchString);
        void AddCountry(string code,string? name);
        void RemoveCountry(string code);
        
    
    }
}