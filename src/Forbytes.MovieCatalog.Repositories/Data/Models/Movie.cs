using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Forbytes.MovieCatalog.Repositories.Data.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Plot { get; set; }

        public string FullPlot { get; set; }

        public DateTime Released { get; set; }

        public string Rated { get; set; }

        public string Poster { get; set; }

        public List<string> Cast { get; set; }

        public List<string> Directors { get; set; }

        public List<string> Writers { get; set; }

        public List<string> Countries { get; set; }

        public List<string> Genres { get; set; }

        public List<string> Languages { get; set; }

        public int Runtime { get; set; }

        public Imdb Imdb { get; set; }

        public Awards Awards { get; set; }

        public int NumberOfComments { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}