using System.Collections.Concurrent;
using BlockedCountries.Dtos;
using BlockedCountries.Services.Repository.IRepository;

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

        public void AddCountry(string code, string? name)
        {

            _countries.TryAdd(code, new Country { Code = code, Name = name });
        }
        public void RemoveCountry(string code)
        {
            _countries.TryRemove(code, out _);
        }


        private void SeedCountries()
        {
            _countries.TryAdd("US", new Country { Code = "US", Name = "United States" });
            _countries.TryAdd("EG", new Country { Code = "EG", Name = "Egypt" });
            _countries.TryAdd("DE", new Country { Code = "DE", Name = "Germany" });
            _countries.TryAdd("IN", new Country { Code = "IN", Name = "India" });
            _countries.TryAdd("GB", new Country { Code = "GB", Name = "United Kingdom" });
            _countries.TryAdd("CA", new Country { Code = "CA", Name = "Canada" });
            _countries.TryAdd("AU", new Country { Code = "AU", Name = "Australia" });
            _countries.TryAdd("JP", new Country { Code = "JP", Name = "Japan" });
            _countries.TryAdd("CN", new Country { Code = "CN", Name = "China" });
            _countries.TryAdd("BR", new Country { Code = "BR", Name = "Brazil" });
            _countries.TryAdd("FR", new Country { Code = "FR", Name = "France" });
            _countries.TryAdd("IT", new Country { Code = "IT", Name = "Italy" });
            _countries.TryAdd("ES", new Country { Code = "ES", Name = "Spain" });
            _countries.TryAdd("RU", new Country { Code = "RU", Name = "Russia" });
            _countries.TryAdd("ZA", new Country { Code = "ZA", Name = "South Africa" });
            _countries.TryAdd("MX", new Country { Code = "MX", Name = "Mexico" });
            _countries.TryAdd("KR", new Country { Code = "KR", Name = "South Korea" });
            _countries.TryAdd("SA", new Country { Code = "SA", Name = "Saudi Arabia" });
            _countries.TryAdd("TR", new Country { Code = "TR", Name = "Turkey" });
            _countries.TryAdd("NL", new Country { Code = "NL", Name = "Netherlands" });
            _countries.TryAdd("SE", new Country { Code = "SE", Name = "Sweden" });
            _countries.TryAdd("CH", new Country { Code = "CH", Name = "Switzerland" });
            _countries.TryAdd("AR", new Country { Code = "AR", Name = "Argentina" });
            _countries.TryAdd("PK", new Country { Code = "PK", Name = "Pakistan" });
            _countries.TryAdd("BD", new Country { Code = "BD", Name = "Bangladesh" });
            _countries.TryAdd("NG", new Country { Code = "NG", Name = "Nigeria" });
            _countries.TryAdd("KE", new Country { Code = "KE", Name = "Kenya" });
            _countries.TryAdd("TH", new Country { Code = "TH", Name = "Thailand" });
            _countries.TryAdd("VN", new Country { Code = "VN", Name = "Vietnam" });
            _countries.TryAdd("PL", new Country { Code = "PL", Name = "Poland" });
            _countries.TryAdd("BE", new Country { Code = "BE", Name = "Belgium" });
            _countries.TryAdd("GR", new Country { Code = "GR", Name = "Greece" });
            _countries.TryAdd("PT", new Country { Code = "PT", Name = "Portugal" });
            _countries.TryAdd("IE", new Country { Code = "IE", Name = "Ireland" });
            _countries.TryAdd("NO", new Country { Code = "NO", Name = "Norway" });
            _countries.TryAdd("FI", new Country { Code = "FI", Name = "Finland" });
            _countries.TryAdd("DK", new Country { Code = "DK", Name = "Denmark" });
            _countries.TryAdd("AT", new Country { Code = "AT", Name = "Austria" });
            _countries.TryAdd("CZ", new Country { Code = "CZ", Name = "Czech Republic" });
            _countries.TryAdd("HU", new Country { Code = "HU", Name = "Hungary" });
            _countries.TryAdd("RO", new Country { Code = "RO", Name = "Romania" });
            _countries.TryAdd("UA", new Country { Code = "UA", Name = "Ukraine" });
            _countries.TryAdd("SG", new Country { Code = "SG", Name = "Singapore" });
            _countries.TryAdd("MY", new Country { Code = "MY", Name = "Malaysia" });
            _countries.TryAdd("PH", new Country { Code = "PH", Name = "Philippines" });
            _countries.TryAdd("ID", new Country { Code = "ID", Name = "Indonesia" });
            _countries.TryAdd("CO", new Country { Code = "CO", Name = "Colombia" });
            _countries.TryAdd("CL", new Country { Code = "CL", Name = "Chile" });
            _countries.TryAdd("PE", new Country { Code = "PE", Name = "Peru" });
            _countries.TryAdd("VE", new Country { Code = "VE", Name = "Venezuela" });
            _countries.TryAdd("NZ", new Country { Code = "NZ", Name = "New Zealand" });
            _countries.TryAdd("QA", new Country { Code = "QA", Name = "Qatar" });
            _countries.TryAdd("AE", new Country { Code = "AE", Name = "United Arab Emirates" });
            _countries.TryAdd("KW", new Country { Code = "KW", Name = "Kuwait" });
            _countries.TryAdd("OM", new Country { Code = "OM", Name = "Oman" });
            _countries.TryAdd("BH", new Country { Code = "BH", Name = "Bahrain" });
            _countries.TryAdd("JO", new Country { Code = "JO", Name = "Jordan" });
            _countries.TryAdd("LB", new Country { Code = "LB", Name = "Lebanon" });
            _countries.TryAdd("IQ", new Country { Code = "IQ", Name = "Iraq" });
            _countries.TryAdd("SY", new Country { Code = "SY", Name = "Syria" });
            _countries.TryAdd("YE", new Country { Code = "YE", Name = "Yemen" });
            _countries.TryAdd("AF", new Country { Code = "AF", Name = "Afghanistan" });
            _countries.TryAdd("LK", new Country { Code = "LK", Name = "Sri Lanka" });
            _countries.TryAdd("NP", new Country { Code = "NP", Name = "Nepal" });
            _countries.TryAdd("MM", new Country { Code = "MM", Name = "Myanmar" });
            _countries.TryAdd("KH", new Country { Code = "KH", Name = "Cambodia" });
            _countries.TryAdd("LA", new Country { Code = "LA", Name = "Laos" });
            _countries.TryAdd("MN", new Country { Code = "MN", Name = "Mongolia" });
            _countries.TryAdd("BT", new Country { Code = "BT", Name = "Bhutan" });
            _countries.TryAdd("MV", new Country { Code = "MV", Name = "Maldives" });
            _countries.TryAdd("TL", new Country { Code = "TL", Name = "Timor-Leste" });
            _countries.TryAdd("PG", new Country { Code = "PG", Name = "Papua New Guinea" });
            _countries.TryAdd("FJ", new Country { Code = "FJ", Name = "Fiji" });
            _countries.TryAdd("SB", new Country { Code = "SB", Name = "Solomon Islands" });
            _countries.TryAdd("VU", new Country { Code = "VU", Name = "Vanuatu" });
            _countries.TryAdd("WS", new Country { Code = "WS", Name = "Samoa" });
            _countries.TryAdd("TO", new Country { Code = "TO", Name = "Tonga" });
            _countries.TryAdd("KI", new Country { Code = "KI", Name = "Kiribati" });
            _countries.TryAdd("FM", new Country { Code = "FM", Name = "Micronesia" });
            _countries.TryAdd("MH", new Country { Code = "MH", Name = "Marshall Islands" });
            _countries.TryAdd("PW", new Country { Code = "PW", Name = "Palau" });
            _countries.TryAdd("NR", new Country { Code = "NR", Name = "Nauru" });
            _countries.TryAdd("TV", new Country { Code = "TV", Name = "Tuvalu" });
        }
    }
}