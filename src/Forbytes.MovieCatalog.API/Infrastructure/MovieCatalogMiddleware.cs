using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace Forbytes.MovieCatalog.API.Infrastructure
{
    internal class MovieCatalogMiddleware
    {
        private readonly RequestDelegate _next;

        public MovieCatalogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            ILogger<MovieCatalogMiddleware> logger
        )
        {
            var stopWatch = Stopwatch.StartNew();
            var level = LogLevel.Information;

            try
            {
                await _next(context);
            }
            catch (Exception) when (context.RequestAborted.IsCancellationRequested)
            {
                level = LogLevel.Debug;
                throw;
            }
            catch (Exception ex)
            {
                level = LogLevel.Error;
                logger.LogCritical(ex, $"Unhandled exception caught in request pipeline. '{ex.GetBaseException().Message}'");
                throw;
            }
            finally
            {
                if (level != LogLevel.Information)
                    logger.Log(level,
                        "Request info: {Info}",
                        new
                        {
                            Timestamp = DateTime.UtcNow,
                            RequestMethod = context.Request.Method,
                            StatusCode = context.Response.StatusCode,
                            Message = context.Request.GetDisplayUrl(),
                            Duration = stopWatch.ElapsedMilliseconds,
                            MachineName = Environment.MachineName,
                            Query = context.Request.QueryString
                        }
                    );
            }
        }
    }
}