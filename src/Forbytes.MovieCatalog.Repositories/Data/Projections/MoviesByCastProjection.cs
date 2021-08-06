using System.Collections.Generic;
using Forbytes.MovieCatalog.Repositories.Data.Models;

namespace Forbytes.MovieCatalog.Repositories.Data.Projections
{
    public class MoviesByCastProjection
    {
        public List<Movie> Movies { get; set; }

        public int Count { get; set; }
    }
}