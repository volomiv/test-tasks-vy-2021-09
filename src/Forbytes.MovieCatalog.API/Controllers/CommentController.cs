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
    [Route("api/v1/movies/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentsAppService _commentsService;
        private readonly IMapper _mapper;

        public CommentController(
            ILogger<CommentController> logger,
            ICommentsAppService commentsService,
            IMapper mapper)
        {
            _logger = logger;
            _commentsService = commentsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AddComment([FromBody] AddCommentInputApiModel input, CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.AddComment(
                input.MovieId,
                input.UserName,
                input.UserEmail,
                input.Comment,
                cancellationToken);

            return result.IsSuccess
                ? Ok(result.Value)
                : BadRequest(result.Error);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCommentAsync([FromBody] UpdateCommentInputApiModel input, CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.UpdateComment(
                input.CommentId,
                input.Comment,
                cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCommentAsync([FromBody] DeleteCommentInputApiModel input, CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.DeleteComment(
                input.CommentId,
                cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpGet("report")]
        public async Task<ActionResult> MostActiveCommentersReport(CancellationToken cancellationToken = default)
        {
            var result = await _commentsService.GetMostActiveCommenters(
                20,
                cancellationToken);

            return Ok(_mapper.Map<TopCommentersApiModel>(result));
        }
    }
}