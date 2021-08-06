using MongoDB.Bson.Serialization.Attributes;

namespace Forbytes.MovieCatalog.Repositories.Data.Projections
{
    public class IdCountProjection
    {
        [BsonElement("_id")]
        public string Id { get; set; }
        public int Count { get; set; }
    }
}