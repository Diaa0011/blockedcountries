using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Service.IService
{
    public interface IIpService
    {
        Task<IpGeoData> GetIpGeoData(string ip);
    }
}