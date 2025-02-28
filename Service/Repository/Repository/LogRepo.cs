using System.Collections.Concurrent;
using BlockedCountries.Dtos;
using BlockedCountries.Service.Repository.IRepository;

namespace BlockedCountries.Service.Repository.Repository
{
    public class LogRepo:ILogRepo
    {
        /*private readonly ConcurrentDictionary<string, BlockedLogsData> logs =
                new ConcurrentDictionary<string, BlockedLogsData>();*/
        private readonly List<BlockedLogsData> logs = new List<BlockedLogsData>();

        public async Task AddLog(BlockedLogsData log)
        {
            logs.Add(log);
        }

        public async Task<IEnumerable<BlockedLogsData>> GetLogs()
        {
            var logsData = logs.AsEnumerable();

            return logsData;
        }
    }
}