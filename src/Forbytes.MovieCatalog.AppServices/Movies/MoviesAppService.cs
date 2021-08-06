using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Forbytes.Core;
using Forbytes.Core.LanguageExtensions;
using Forbytes.MovieCatalog.AppServices.Models;
using Forbytes.MovieCatalog.Repositories.Repositories;

namespace Forbytes.MovieCatalog.AppServices.Comments
{
    internal class MoviesAppService : IMoviesAppService
    {
        private readonly IMoviesRepository _repository;
        private readonly IMapper _mapper;

        public MoviesAppService(
            IMoviesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<MovieModel>> GetMovie(string movieId, CancellationToken cancellationToken = default)
        {
            var movie = await _repository.GetMovie(movieId, cancellationToken);

            if (movie != null)
                return _mapper.Map<MovieModel>(movie);

            return new ErrorModel
            {
                Error = ErrorCodeConstants.Request.NotFound,
                Message = $"Movie with id '{movieId}' was not found."
            };
        }

        public async Task<IReadOnlyList<MovieModel>> GetMoviesInChunks(
            int moviesPerPage,
            int page,
            string sort,
            int sortDirection,
            CancellationToken cancellationToken = default)
        {
            var movies =
                await _repository.GetMoviesInChunks(moviesPerPage, page, sort, sortDirection, cancellationToken);
                
            return _mapper.Map<IReadOnlyList<MovieModel>>(movies);
        }

        public async Task<MoviesByCastModel> GetMoviesByCastWithCount(string cast, int page = 0, CancellationToken cancellationToken = default)
        {
            var movies = await _repository.GetMoviesByCastWithCount(cast, page, cancellationToken);

            return _mapper.Map<MoviesByCastModel>(movies);
        }
    }
}