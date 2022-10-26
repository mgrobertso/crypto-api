using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Crypto.Core.Services
{
    public class GeckoService : BackgroundService
    {

        private readonly ILogger<GeckoService> _logger;
        private readonly TimeSpan _period = TimeSpan.FromSeconds(30);
        private readonly IServiceScopeFactory _factory;
        private int _executionCount = 0;
        public bool IsEnabled { get; set; }

        public GeckoService(ILogger<GeckoService> logger, IServiceScopeFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    if (IsEnabled)
                    {
                        await using AsyncServiceScope asyncScope = _factory.CreateAsyncScope();
                        ICryptoService cryptoService = asyncScope.ServiceProvider.GetRequiredService<ICryptoService>();
                        await cryptoService.GetCryptoAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=250&page=1&sparkline=false");
                        var page = 2;
                        _executionCount++;
                        _logger.LogInformation(
                            $"Executed geckoservice - Count: {_executionCount}");
                    }
                    else
                    {
                        _logger.LogInformation(
                            "Skipped geckoservice");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(
                        $"Failed to execute geckoService with exception message {ex.Message}.");
                }
            }
        }
    }
}
