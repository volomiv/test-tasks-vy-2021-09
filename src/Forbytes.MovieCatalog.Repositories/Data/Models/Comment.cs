using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Forbytes.MovieCatalog.Repositories.Data.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string MovieId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}