using System.Text.Json;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Repository.IRepository;

namespace BlockedCountries.Service.Repository.Repository
{
    public class IpRepo : IIpRepo
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public IpRepo(HttpClient client, IConfiguration configuration)
        {
            _client = client ??
                 throw new ArgumentNullException(nameof(client));
            _configuration = configuration ??
                 throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IpGeoData> GetIpGeoData(string? ip)
        {
            var baseUrl = _configuration["IpGeolocation:BaseUrl"];
            var apiKey = _configuration["IpGeolocation:ApiKey"];

            var url = $"{baseUrl}?apiKey={apiKey}&ip={ip}";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var ipGeoData = JsonSerializer.Deserialize<IpGeoData>(json);
            
            return ipGeoData;
        }
    }
}