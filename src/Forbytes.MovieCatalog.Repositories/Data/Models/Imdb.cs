using MongoDB.Bson.Serialization.Attributes;

namespace Forbytes.MovieCatalog.Repositories.Data.Models
{
    public class Imdb
    {
        [BsonElement("id")]
        public int ImdbId { get; set; }
        public int Votes { get; set; }
        public double Rating { get; set; }
    }
}