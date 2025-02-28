using BlockedCountries.Service.Service.IService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlockedCountries.Service.Service.Service
{
    public class unBlockTempService : BackgroundService
    {
        private readonly ILogger<unBlockTempService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public unBlockTempService(ILogger<unBlockTempService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Background task is running at: {time}", DateTimeOffset.Now);
                    await DoWorkAsync(stoppingToken);
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the background task.");
            }

            _logger.LogInformation("Timed background task is stopping.");
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Doing Work...");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var countryService = scope.ServiceProvider.GetRequiredService<ICountryService>();

                _logger.LogInformation("Temporal Countries scan and removal is running.");
                var countries = countryService.GetCountries(1, 250, null);

                foreach (var country in countries)
                {
                    if (country.temporalBlocked)
                    {
                        TimeSpan timeElapsed = DateTime.UtcNow - country.CreatedAt;
                        int elapsedMinutes = (int)timeElapsed.TotalMinutes;

                        if (elapsedMinutes >= country.TemporalBlockTime)
                        {
                            countryService.RemoveCountry(country.Code);
                            _logger.LogInformation($"Unblocked country {country.Code}");
                        }
                    }
                }
            }
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            _logger.LogInformation("Work completed.");
        }
    }
}
