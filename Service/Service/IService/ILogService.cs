using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Service.IService
{
    public interface ILogService
    {

        public Task AddLog(IpGeoData geoData,bool isBlocked);
        

        public Task<IEnumerable<BlockedLogsData>> GetLogs(int pageNumber, int pageSize);
        
    }
}