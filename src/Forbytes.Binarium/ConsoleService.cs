using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Forbytes.Binarium
{
    public class ConsoleService : IHostedService
    {
        private readonly ILogger<App> _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly App _app;

        public ConsoleService(
            ILogger<App> logger,
            IHostApplicationLifetime appLifetime,
            App app)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _app = app;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(() =>
                {
                    try
                    {
                        _app.Run();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception!");
                    }
                    finally
                    {
                        _appLifetime.StopApplication();
                    }
                }, cancellationToken);
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
