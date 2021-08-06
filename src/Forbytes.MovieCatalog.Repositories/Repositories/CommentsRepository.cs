using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Forbytes.MovieCatalog.Repositories.Data;
using Forbytes.MovieCatalog.Repositories.Data.Models;
using Forbytes.MovieCatalog.Repositories.Data.Projections;
using MongoDB.Driver;

namespace Forbytes.MovieCatalog.Repositories.Repositories
{
    internal class CommentsRepository : ICommentsRepository
    {
        private readonly DbContext _context;

        public CommentsRepository(DbContext context)
        {
            _context = context;
        }

        public Task<Comment> GetComment(string commentId, CancellationToken cancellationToken = default)
        {
            return _context.Comments
                .Find(Builders<Comment>.Filter.Eq(c => c.Id, commentId))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<string> AddComment(string movieId, string userName, string userEmail, string comment,
            CancellationToken cancellationToken = default)
        {
            var newComment = new Comment
            {
                MovieId = movieId,
                Name = userName,
                Email = userEmail,
                Text = comment,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Comments.InsertOneAsync(newComment, default, cancellationToken);

            return newComment.Id;
        }

        public Task<UpdateResult> UpdateComment(string commentId, string comment, CancellationToken cancellationToken = default)
        {
            return _context.Comments.UpdateOneAsync(
                Builders<Comment>.Filter.Eq(c => c.Id, commentId),
                Builders<Comment>.Update
                    .Set(c => c.Text, comment)
                    .Set(c => c.UpdatedAt, DateTime.UtcNow),
                new UpdateOptions { IsUpsert = false },
                cancellationToken);
        }

        public Task<DeleteResult> DeleteComment(string commentId, CancellationToken cancellationToken = default)
        {
            return _context.Comments.DeleteOneAsync(
                Builders<Comment>.Filter.Eq(c => c.Id, commentId),
                cancellationToken);
        }

        public async Task<TopCommentersProjection> GetMostActiveCommenters(int limit, CancellationToken cancellationToken = default)
        {
            var query = _context.Comments
                .WithReadConcern(ReadConcern.Majority)
                .Aggregate()
                .Group(c => c.Email, g => new IdCountProjection { Id = g.Key, Count = g.Count() })
                .SortByDescending(g => g.Count)
                .Limit(limit);

            var raw = query.ToString();

            var result = await query.ToListAsync(cancellationToken);

            return new TopCommentersProjection{Items = result};
        }
    }
}