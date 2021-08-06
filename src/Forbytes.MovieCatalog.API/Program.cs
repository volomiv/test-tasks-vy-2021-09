using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Forbytes.MovieCatalog.API
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    var reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                    config
                        .AddJsonFile(@"./config/appsettings.json", true, reloadOnChange)
                        .AddEnvironmentVariables();
                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    if (!hostingContext.HostingEnvironment.IsDevelopment())
                        builder.ClearProviders();
                    builder.AddNLog(new NLogLoggingConfiguration(hostingContext.Configuration.GetSection("NLog")));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseUrls("http://+:64100;https://+:64101");
                })
                .Build()
                .RunAsync();
        }
    }
}