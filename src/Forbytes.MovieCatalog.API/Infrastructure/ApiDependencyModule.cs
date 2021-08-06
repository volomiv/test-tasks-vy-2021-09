using Forbytes.Core.Application;
using Forbytes.Core.DependencyInjection;
using Forbytes.MovieCatalog.AppServices;
using Forbytes.MovieCatalog.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Forbytes.MovieCatalog.API.Infrastructure
{
    public class ApiDependencyModule : IDependencyModule
    {
        public void Register(IServiceCollection builder)
        {
            builder.RegisterModule<RepositoriesDependencyModule>();
            builder.RegisterModule<AppServicesDependencyModule>();

            builder.AddSingleton<IApplication, ApiApplication>();

            builder.AddAutoMapper(typeof(ApiDependencyModule));
        }
    }
}