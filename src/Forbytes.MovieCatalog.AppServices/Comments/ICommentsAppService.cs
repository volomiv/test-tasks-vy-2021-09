using System.Threading;
using System.Threading.Tasks;
using Forbytes.Core.LanguageExtensions;
using Forbytes.MovieCatalog.AppServices.Models;

namespace Forbytes.MovieCatalog.AppServices.Comments
{
    public interface ICommentsAppService
    {
        Task<Result<string>> AddComment(string movieId, string userName, string userEmail, string comment, CancellationToken cancellationToken = default);

        Task<Result> UpdateComment(string commentId, string comment, CancellationToken cancellationToken = default);

        Task<Result> DeleteComment(string commentId, CancellationToken cancellationToken = default);

        Task<TopCommentersModel> GetMostActiveCommenters(int limit, CancellationToken cancellationToken = default);
    }
}