using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<ActionResult<string>> GetMovie(string movieId, CancellationToken cancellationToken = default)
        {
            return "";
        }
    }
}