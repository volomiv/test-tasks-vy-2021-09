using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Forbytes.Core;
using Forbytes.MovieCatalog.API.ApiModels;
using Forbytes.MovieCatalog.AppServices.Comments;
using Microsoft.AspNetCore.Mvc;

namespace Forbytes.MovieCatalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesAppService _moviesService;
        private readonly IMapper _mapper;

        public MovieController(
            IMoviesAppService moviesService,
            IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(typeof(MovieApiModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<ActionResult> GetMovie(string movieId, CancellationToken cancellationToken = default)
        {
            var result = await _moviesService.GetMovie(movieId, cancellationToken);

            return result.IsSuccess
                ? Ok(_mapper.Map<MovieApiModel>(result.Value))
                : BadRequest(result.Error);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IReadOnlyList<MovieApiModel>), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<ActionResult> GetMoviesInChunks(
            int limit = 20,
            [FromQuery(Name = "page")] int page = 0,
            string sort = "imdb.rating",
            int sortDirection = -1,
            CancellationToken cancellationToken = default)
        {
            var result = await _moviesService.GetMoviesInChunks(
                limit,
                page,
                sort,
                sortDirection,
                cancellationToken);

            return Ok(_mapper.Map<IReadOnlyList<MovieApiModel>>(result));
        }

        [HttpGet("search/cast-{cast}/{page?}")]
        [ProducesResponseType(typeof(MoviesByCastApiModel), 200)]
        public async Task<ActionResult> GetMoviesByCastAsync(string cast, int page = 0, CancellationToken cancellationToken = default)
        {
            var movies = await _moviesService.GetMoviesByCastWithCount(cast, page, cancellationToken);

            return Ok(_mapper.Map<MoviesByCastApiModel>(movies));
        }
    }
}