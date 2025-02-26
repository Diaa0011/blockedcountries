
using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Repository.IRepository
{
    public interface ICountryRepo
    {
        Country GetCountry(string code);
        bool CountryExists(string code);
        IEnumerable<Country> GetCountries();
        void AddCountry(string code, string? name);
        void RemoveCountry(string code);
    }
}