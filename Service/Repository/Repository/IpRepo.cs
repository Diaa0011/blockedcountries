using BlockedCountries.Dtos;
using BlockedCountries.Service.Repository.IRepository;

namespace BlockedCountries.Service.Repository.Repository
{
    public class IpRepo : IIpRepo
    {
        

        public Task<IpGeoData> GetIpGeoData(string? ip)
        {
            throw new NotImplementedException();
        }
    }
}