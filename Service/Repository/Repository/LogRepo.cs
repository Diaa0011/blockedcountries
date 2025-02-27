using System.Collections.Concurrent;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Repository.IRepository;

namespace BlockedCountries.Service.Repository.Repository
{
    public class LogRepo:ILogRepo
    {
        private readonly ConcurrentDictionary<string, BlockedLogsData> logs =
                new ConcurrentDictionary<string, BlockedLogsData>();

        public void AddLog(BlockedLogsData log)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlockedLogsData> GetLogs(int pageNumber, int pageSize, string? searchString)
        {
            throw new NotImplementedException();
        }
    }
}