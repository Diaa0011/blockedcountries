using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Repository.IRepository
{
    public interface IIpRepo
    {
        Task<IpGeoData> GetIpGeoData(string? ip);
    }
}