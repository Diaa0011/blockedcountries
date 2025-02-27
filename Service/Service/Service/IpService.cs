using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Service.IService;
namespace BlockedCountries.Service.Service
{
    public class IpService : IIpService
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
            if (ip == null)
            {
                //very important to note that it will work only on production
                //evnrionment, in development it will return the localhost ip
                //used ngrok server to test it
                ip = GetHttpContextIp();
                Console.WriteLine("Ip: ", ip);
            }
            //Check if the IP is valid
            if (!validIP(ip))
            {
                throw new ArgumentException("Invalid IP address");
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
        private string GetHttpContextIp()
        {
            //Get the real IP address if you are running behind a reverse proxy as NGINX or Apache
            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedIp))
            {
                var realIP = forwardedIp.ToString().Split(',').FirstOrDefault();
                if (!string.IsNullOrEmpty(realIP))
                {
                    return realIP;
                }
            }

            if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("X-Real-IP", out var realIpHeader))
            {
                var realIp = realIpHeader.ToString();
                if (!string.IsNullOrEmpty(realIp))
                {
                    return realIp;
                }
            }

            var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

            if (ipAddress == null)
            {
                return "Unknown";
            }

            if (ipAddress.IsIPv4MappedToIPv6)
            {
                ipAddress = ipAddress.MapToIPv4();
            }

            return ipAddress.ToString();

        }
        private bool validIP(string ip)
        {
            return IPAddress.TryParse(ip,out IPAddress Address) &&
                     (Address.AddressFamily == AddressFamily.InterNetwork || Address.AddressFamily == AddressFamily.InterNetworkV6);
        }
    }
}