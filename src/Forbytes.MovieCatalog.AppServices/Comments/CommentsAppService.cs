using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Forbytes.Core;
using Forbytes.Core.LanguageExtensions;
using Forbytes.MovieCatalog.AppServices.Models;
using Forbytes.MovieCatalog.Repositories.Repositories;

namespace Forbytes.MovieCatalog.AppServices.Comments
{
    internal class CommentsAppService : ICommentsAppService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;

        public CommentsAppService(
            ICommentsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<string>> AddComment(string movieId, string userName, string userEmail, string comment,
            CancellationToken cancellationToken = default)
        {
            var commentId = await _repository.AddComment(movieId, userName, userEmail, comment, cancellationToken);

            if (string.IsNullOrEmpty(commentId))
                return new ErrorModel
                {
                    Error = ErrorCodeConstants.Request.Invalid,
                    Message = "Comment was not added."
                };

            return commentId;
        }

        public async Task<Result> UpdateComment(string commentId, string comment, CancellationToken cancellationToken = default)
        {
            var result = await _repository.UpdateComment(commentId, comment, cancellationToken);

            if (result.IsAcknowledged && result.ModifiedCount == 1)
                return Result.Success;

            return new ErrorModel
            {
                Error = ErrorCodeConstants.Request.Invalid,
                Message = $"Comment with id '{commentId}' was not updated (or not found)."
            };
        }

        public async Task<Result> DeleteComment(string commentId, CancellationToken cancellationToken = default)
        {
            var result = await _repository.DeleteComment(commentId, cancellationToken);

            if (result.IsAcknowledged && result.DeletedCount == 1)
                return Result.Success;

            return new ErrorModel
            {
                Error = ErrorCodeConstants.Request.Invalid,
                Message = $"Comment with id '{commentId}' was not deleted (or not found)."
            };
        }

        public async Task<TopCommentersModel> GetMostActiveCommenters(int limit, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetMostActiveCommenters(limit, cancellationToken);

            return _mapper.Map<TopCommentersModel>(result);
        }
    }
}