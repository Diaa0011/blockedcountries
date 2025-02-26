using System.Text.Json.Serialization;

namespace BlockedCountries.Dtos
{
    public record IpGeoData
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("country_code2")]
        public string CountryCode{ get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; } // JSON returns latitude as a string

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; } // JSON returns longitude as a string
    }
}