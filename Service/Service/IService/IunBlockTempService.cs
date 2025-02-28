namespace BlockedCountries.Service.Service.IService
{
    public interface IunBlockTempService:IHostedService
    {
        Task ExecuteAsync(CancellationToken stoppingToken);
    }
}