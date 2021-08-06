using System.Threading;
using System.Threading.Tasks;
using Forbytes.MovieCatalog.Repositories.Data.Models;
using Forbytes.MovieCatalog.Repositories.Data.Projections;
using MongoDB.Driver;

namespace Forbytes.MovieCatalog.Repositories.Repositories
{
    public interface ICommentsRepository
    {
        Task<Comment> GetComment(string commentId, CancellationToken cancellationToken = default);

        Task<string> AddComment(string movieId, string userName, string userEmail, string comment, CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateComment(string commentId, string comment, CancellationToken cancellationToken = default);

        Task<DeleteResult> DeleteComment(string commentId, CancellationToken cancellationToken = default);

        Task<TopCommentersProjection> GetMostActiveCommenters(int limit, CancellationToken cancellationToken = default);
    }
}