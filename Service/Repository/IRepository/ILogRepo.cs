using BlockedCountries.Dtos;

namespace BlockedCountries.Service.Repository.IRepository
{
    public interface ILogRepo
    {
        void AddLog(BlockedLogsData log);
        IEnumerable<BlockedLogsData> GetLogs(int pageNumber, int pageSize, string? searchString);
    }
}