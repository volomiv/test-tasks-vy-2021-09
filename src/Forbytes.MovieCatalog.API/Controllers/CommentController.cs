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
    [Route("api/v1/movies/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsAppService _commentsService;
        private readonly IMoviesAppService _moviesService;
        private readonly IMapper _mapper;

        public CommentController(
            ICommentsAppService commentsService,
            IMoviesAppService moviesService,
            IMapper mapper)
        {
            _commentsService = commentsService;
            _moviesService = moviesService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MovieApiModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<ActionResult> AddComment([FromBody] AddCommentInputApiModel input, CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.AddComment(
                input.MovieId,
                input.UserName,
                input.UserEmail,
                input.Comment,
                cancellationToken);

            if (result.IsError)
                return BadRequest(result.Error);

            var movieResult = await _moviesService.GetMovie(input.MovieId, cancellationToken);

            return movieResult.IsSuccess
                ? Ok(movieResult.Value)
                : BadRequest(movieResult.Error);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<ActionResult> UpdateCommentAsync([FromBody] UpdateCommentInputApiModel input, CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.UpdateComment(
                input.CommentId,
                input.Comment,
                cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<ActionResult> DeleteCommentAsync([FromBody] DeleteCommentInputApiModel input, CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.DeleteComment(
                input.CommentId,
                cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpGet("report")]
        [ProducesResponseType(typeof(TopCommentersApiModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        public async Task<ActionResult> MostActiveCommentersReport(CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.GetMostActiveCommenters(
                20,
                cancellationToken);

            return Ok(_mapper.Map<TopCommentersApiModel>(result));
        }
    }
}