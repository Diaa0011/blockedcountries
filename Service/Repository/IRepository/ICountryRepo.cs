using Entities;

namespace BlockedCountries.Services.Repository.IRepository
{
    public interface ICountryRepo
    {
        Country GetCountry(string code);
        IEnumerable<Country> GetCountries();
        void AddCountry(string code, bool? isBlocked);
    }
}