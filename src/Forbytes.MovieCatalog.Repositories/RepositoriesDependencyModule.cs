using Forbytes.Core.DependencyInjection;
using Forbytes.MovieCatalog.Repositories.Data;
using Forbytes.MovieCatalog.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Forbytes.MovieCatalog.Repositories
{
    public class RepositoriesDependencyModule : IDependencyModule
    {
        public void Register(IServiceCollection builder)
        {
            builder.AddScoped<DbContext>();

            builder.AddScoped<ICommentsRepository, CommentsRepository>();
            builder.AddScoped<IMoviesRepository, MoviesRepository>();
        }
    }
}