using System.Collections;
using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Service.IService
{
    public interface ICountryService
    {
        //Task<string> GetCountryCode(string ip);
        Country GetCountry(string code);
        IEnumerable<Country> GetCountries(int pageNumber,int pageSize,string? searchString);
        void AddCountry(string code,string? name, bool temporalBlocked = false, int? TemporalBlockTime = null);
        void RemoveCountry(string code);
        
    
    }
}