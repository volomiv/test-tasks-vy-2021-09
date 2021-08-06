using System;

namespace Forbytes.MovieCatalog.API.ApiModels
{
    public class CommentApiModel
    {
        public string Id { get; set; }
        public string MovieId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}