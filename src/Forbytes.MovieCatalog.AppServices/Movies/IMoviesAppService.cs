using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Forbytes.Core.LanguageExtensions;
using Forbytes.MovieCatalog.AppServices.Models;

namespace Forbytes.MovieCatalog.AppServices.Comments
{
    public interface IMoviesAppService
    {
        Task<Result<MovieModel>> GetMovie(string movieId, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<MovieModel>> GetMoviesInChunks(
            int moviesPerPage,
            int page,
            string sort,
            int sortDirection,
            CancellationToken cancellationToken = default);

        Task<MoviesByCastModel> GetMoviesByCastWithCount(
            string cast,
            int page = 0,
            CancellationToken cancellationToken = default);
    }
}