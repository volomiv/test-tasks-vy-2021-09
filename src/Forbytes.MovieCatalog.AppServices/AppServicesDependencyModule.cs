using Forbytes.Core.DependencyInjection;
using Forbytes.MovieCatalog.AppServices.Comments;
using Microsoft.Extensions.DependencyInjection;

namespace Forbytes.MovieCatalog.AppServices
{
    public class AppServicesDependencyModule : IDependencyModule
    {
        public void Register(IServiceCollection builder)
        {
            builder.AddAutoMapper(typeof(AppServicesDependencyModule));

            builder.AddScoped<ICommentsAppService, CommentsAppService>();
            builder.AddScoped<IMoviesAppService, MoviesAppService>();
        }
    }
}