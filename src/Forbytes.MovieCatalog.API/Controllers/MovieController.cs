using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Forbytes.MovieCatalog.API.ApiModels;
using Forbytes.MovieCatalog.AppServices.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forbytes.MovieCatalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMoviesAppService _moviesService;
        private readonly IMapper _mapper;

        public MovieController(
            ILogger<MovieController> logger,
            IMoviesAppService moviesService,
            IMapper mapper)
        {
            _logger = logger;
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult> GetMovie(string movieId, CancellationToken cancellationToken = default)
        {
            var result = await _moviesService.GetMovie(movieId, cancellationToken);

            return result.IsSuccess
                ? Ok(_mapper.Map<MovieApiModel>(result.Value))
                : BadRequest(result.Error);
        }

        [HttpGet("")]
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
        public async Task<ActionResult> GetMoviesByCastAsync(string cast, int page = 0, CancellationToken cancellationToken = default)
        {
            var movies = await _moviesService.GetMoviesByCastWithCount(cast, page, cancellationToken);

            return Ok(_mapper.Map<MoviesByCastApiModel>(movies));
        }
    }
}