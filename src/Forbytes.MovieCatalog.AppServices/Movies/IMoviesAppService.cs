using System.Threading;
using System.Threading.Tasks;
using Forbytes.MovieCatalog.Repositories.Data.Projections;
using MongoDB.Driver;

namespace Forbytes.MovieCatalog.AppServices.Comments
{
    public interface IMoviesAppService
    {
        Task AddComment(string movieId, string userName, string userEmail, string comment, CancellationToken cancellationToken = default);

        Task<UpdateResult> UpdateComment(string commentId, string movieId, string userEmail, string comment, CancellationToken cancellationToken = default);

        Task<DeleteResult> DeleteComment(string commentId, string movieId, string userEmail, CancellationToken cancellationToken = default);

        Task<TopCommentersProjection> GetMostActiveCommenters(int limit, CancellationToken cancellationToken = default);
    }
}