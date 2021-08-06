using Forbytes.Core.Configurations;
using Forbytes.MovieCatalog.Repositories.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Forbytes.MovieCatalog.Repositories.Data
{
    internal class DbContext
    {
        static DbContext()
        {
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
        }

        public DbContext(IOptions<DatabaseSettings> settings)
        {
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

            MongoClient = new MongoClient(settings.Value.ConnectionString);
            MongoDatabase = MongoClient.GetDatabase(settings.Value.DatabaseName);

            Movies = MongoDatabase.GetCollection<Movie>("movies");
            Comments = MongoDatabase.GetCollection<Comment>("comments");
        }

        public IMongoClient MongoClient { get; init; }
        public IMongoDatabase MongoDatabase { get; init; }

        public IMongoCollection<Movie> Movies { get; init; }
        public IMongoCollection<Comment> Comments { get; init; }
    }
}