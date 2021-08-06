using System.Threading;
using System.Threading.Tasks;
using Forbytes.MovieCatalog.Repositories.Data.Projections;
using Forbytes.MovieCatalog.Repositories.Repositories;
using MongoDB.Driver;

namespace Forbytes.MovieCatalog.AppServices.Comments
{
    internal class MoviesAppService : IMoviesAppService
    {
        private readonly IMoviesRepository _repository;

        public MoviesAppService(IMoviesRepository repository)
        {
            _repository = repository;
        }

        public Task AddComment(string movieId, string userName, string userEmail, string comment,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateResult> UpdateComment(string commentId, string movieId, string userEmail, string comment,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<DeleteResult> DeleteComment(string commentId, string movieId, string userEmail, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<TopCommentersProjection> GetMostActiveCommenters(int limit, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}