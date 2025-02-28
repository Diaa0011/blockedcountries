using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Repository.IRepository
{
    public interface ILogRepo
    {
        Task AddLog(BlockedLogsData log);
        Task<IEnumerable<BlockedLogsData>> GetLogs();
    }
}