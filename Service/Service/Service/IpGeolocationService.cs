namespace BlockedCountries.Services.Service{
    public class IpGeoLocationService
    {
        private readonly HttpClient _HttpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public IpGeoLocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _HttpClient = httpClient;
            _apiKey = configuration["IpGeolocation:ApiKey"] ??
                      throw new ArgumentNullException("ApiKey is required for IpGeolocationService");
            _baseUrl = configuration["IpGeolocation:BaseUrl"] ??
                       throw new ArgumentNullException("BaseUrl is required for IpGeolocationService");
        }   

        public async Task<string> GetCountryCode(string ip)
        {
            /*
            var url = $"{_baseUrl}/{ip}?apiKey={_apiKey}";
            var response = await _HttpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to get country code for IP: {ip}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var ipGeoLocation = JsonSerializer.Deserialize<IpGeoLocation>(content);
            return ipGeoLocation?.Country?.Code ?? string.Empty;
            */
            var url = $"base: {_baseUrl}, ip: {ip}, apiKey: {_apiKey}";

            var response = await _HttpClient.GetAsync(url); 

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to get country code for IP: {ip}");
            }
            return await response.Content.ReadAsStringAsync();
        }
        
        
    }
}