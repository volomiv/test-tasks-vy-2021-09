using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forbytes.MovieCatalog.Repositories.Data.Models;
using Forbytes.MovieCatalog.Repositories.Data.Projections;

namespace Forbytes.MovieCatalog.Repositories.Repositories
{
    public interface IMoviesRepository
    {
        Task<Movie> GetMovie(string movieId, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Movie>> GetMoviesInChunks(
            int moviesPerPage = MovieSearchConstants.DefaultMoviesPerPage,
            int page = 0,
            string sort = MovieSearchConstants.DefaultSortKey,
            int sortDirection = MovieSearchConstants.DefaultSortOrder,
            CancellationToken cancellationToken = default);

        Task<MoviesByCastProjection> GetMoviesByCastWithCount(
            string cast,
            int page = 0,
            CancellationToken cancellationToken = default);
    }
}