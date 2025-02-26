using System.Text.Json;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Service.IService;
namespace BlockedCountries.Service.Service{
    public class IpService:IIpService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IpService(HttpClient client, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _client = client ??
                 throw new ArgumentNullException(nameof(client));
            _configuration = configuration ??
                 throw new ArgumentNullException(nameof(configuration));
            _httpContextAccessor = httpContextAccessor ??
                    throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        
        public async Task<IpGeoData> GetIpGeoData(string? ip)
        {
            if(ip == null)
            {
                ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
                Console.WriteLine("Ip: ",ip);
            }
            var baseUrl = _configuration["IpGeolocation:BaseUrl"];
            var apikKey = _configuration["IpGeolocation:ApiKey"];

            var url = $"{baseUrl}?apiKey={apikKey}&ip={ip}";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var ipGeoData = JsonSerializer.Deserialize<IpGeoData>(json);

            return ipGeoData;
        
        }
        
        
    }
}