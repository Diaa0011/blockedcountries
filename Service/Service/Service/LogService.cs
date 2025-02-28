using BlockedCountries.Dtos;
using BlockedCountries.Service.Repository.IRepository;
using BlockedCountries.Service.Service.IService;

namespace BlockedCountries.Service.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepo _logRepo;
        private readonly IIpService _ipService;

        public LogService(ILogRepo logRepo, IIpService ipService)
        {
            _logRepo = logRepo??
                throw new ArgumentNullException(nameof(logRepo));
            _ipService = ipService?? 
                throw new ArgumentNullException(nameof(ipService));
        }

        public async Task AddLog(IpGeoData geoData,bool isBlocked)
        {
            if(geoData == null || string.IsNullOrEmpty(geoData.Ip))
            {
                throw new InvalidOperationException("The geoData is null.");
            }
            if(isBlocked == null)
            {
                throw new InvalidOperationException("Error in isBlocked.");
            }
            var ipGeoData = geoData;
            var log = new BlockedLogsData
            {
                ipAddress = ipGeoData.Ip,
                TimeStamp = DateTime.Now,
                CountryCode = ipGeoData.CountryCode,
                BlockedStatus = isBlocked,
                UserAgent = geoData.UserAgent
            };
            _logRepo.AddLog(log);
        }

        public async Task<IEnumerable<BlockedLogsData>> GetLogs(int pageNumber, int pageSize)
        {
            
            var logs = await _logRepo.GetLogs();
            var pagedLogs = logs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            
            return pagedLogs;
        }
    }
}