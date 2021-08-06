using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Forbytes.MovieCatalog.Repositories.Data;
using Forbytes.MovieCatalog.Repositories.Data.Models;
using Forbytes.MovieCatalog.Repositories.Data.Projections;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Forbytes.MovieCatalog.Repositories.Repositories
{
    internal class MoviesRepository : IMoviesRepository
    {
        private readonly DbContext _context;

        public MoviesRepository(DbContext context)
        {
            _context = context;
        }

        public Task<Movie> GetMovie(string movieId, CancellationToken cancellationToken = default)
        {
            return _context.Movies.Aggregate()
                    .Match(Builders<Movie>.Filter.Eq(x => x.Id, movieId))
                    .Lookup(
                        _context.Comments,
                        m => m.Id,
                        c => c.MovieId,
                        (Movie m) => m.Comments)
                    .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Movie>> GetMoviesInChunks(
            int moviesPerPage = MovieSearchConstants.DefaultMoviesPerPage,
            int page = 0,
            string sort = MovieSearchConstants.DefaultSortKey,
            int sortDirection = MovieSearchConstants.DefaultSortOrder,
            CancellationToken cancellationToken = default)
        {
            var movies = await _context.Movies
                .Find(Builders<Movie>.Filter.Empty)
                .Limit(moviesPerPage)
                .Skip(moviesPerPage * page)
                .Sort(new BsonDocument(sort, sortDirection))
                .ToListAsync(cancellationToken);

            return movies;
        }

        public async Task<MoviesByCastProjection> GetMoviesByCastWithCount(
            string cast,
            int page = 0,
            CancellationToken cancellationToken = default)
        {
            var matchStage = new BsonDocument("$match",
                new BsonDocument("cast",
                    new BsonDocument("$in",
                        new BsonArray { cast })));

            var limitStage = new BsonDocument("$limit", MovieSearchConstants.DefaultMoviesPerPage);

            var sortStage = new BsonDocument("$sort",
                new BsonDocument("imdb.rating", -1));

            var skipStage = new BsonDocument("$skip", MovieSearchConstants.DefaultMoviesPerPage * page);

            var facetStage = new BsonDocument("$facet",
                new BsonDocument
                {
                    new BsonElement("movies",
                        new BsonArray
                        {
                            new BsonDocument("$addFields",
                                new BsonDocument("title", "$title"))
                        })
                });

            var pipeline = new[]
            {
                matchStage,
                sortStage,
                skipStage,
                limitStage,
                facetStage
            };

            var result = await _context.Movies
                .Aggregate(PipelineDefinition<Movie, MoviesByCastProjection>.Create(pipeline))
                .FirstOrDefaultAsync(cancellationToken);

            var countPipeline = new[]
            {
                matchStage,
                sortStage,
                new BsonDocument("$count", "count")
            };

            var count = await _context.Movies
                .Aggregate(PipelineDefinition<Movie, BsonDocument>.Create(countPipeline))
                .FirstOrDefaultAsync(cancellationToken);

            result.Count = (int)count.Values.First();

            return result;
        }
    }
}