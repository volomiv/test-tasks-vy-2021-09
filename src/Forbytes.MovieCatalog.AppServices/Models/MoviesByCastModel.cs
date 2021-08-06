using System.Collections.Generic;

namespace Forbytes.MovieCatalog.AppServices.Models
{
    public class MoviesByCastModel
    {
        public List<MovieModel> Movies { get; set; }

        public int Count { get; set; }
    }
}