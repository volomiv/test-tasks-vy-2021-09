﻿using System.IO;
using System.Threading.Tasks;
using Binarium.AppServices;
using Binarium.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Binarium
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile(@"./config/appsettings.json");

                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddHostedService<ConsoleService>()
                        .AddSingleton(_ => new CommandLineArguments { Values = args })
                        .AddSingleton<App>()
                        .AddSingleton<IBinaryStringService, BinaryStringService>();
                })
                .RunConsoleAsync();
        }
    }
}
