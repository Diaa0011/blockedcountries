using System.Collections;
using BlockedCountries.Service.Repository.IRepository;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Service.IService;
namespace BlockedCountries.Service.Service
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
            code = code.ToUpper();
            var country = _countryRepo.GetCountry(code);
            if (country == null)
            {
                throw new InvalidOperationException("The country does not exist.");
            }

            return country;
        }
        public IEnumerable<Country> GetCountries(int pageNumber,int pageSize,string? searchString = null)
        {
            if (_countryRepo == null)
            {
                throw new InvalidOperationException("The country repository is not initialized.");
            }

            var countries = _countryRepo.GetCountries();
            //search
            if (!string.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(c => c.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }
            //pagination and sorting
            var paginatedCountries = countries.Skip((pageNumber -1) * pageSize)
                .Take(pageSize).OrderBy(c=>c.Name);

            return paginatedCountries;
        }
        public void AddCountry(string code,string? name, bool temporalBlocked = false, int? TemporalBlockTime = null)
        {
            code = code.ToUpper();
            if (code == null || code.Length != 2)
            {
                throw new InvalidOperationException("Check you entered the right input.");
            }
            else if (_countryRepo.CountryExists(code))
            {
                throw new InvalidOperationException("The country already exists.");
            }
            else
            {
                try
                {
                    _countryRepo.AddCountry(code,name,temporalBlocked,TemporalBlockTime);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("The country could not be added to the blocked list.");
                }
            }

        }
        public void RemoveCountry(string code)
        {
            var country = _countryRepo.GetCountry(code);
            if (country == null)
            {
                throw new InvalidOperationException("The country does not exist in blocked List.");
            }

            _countryRepo.RemoveCountry(code);
        }


    }
}