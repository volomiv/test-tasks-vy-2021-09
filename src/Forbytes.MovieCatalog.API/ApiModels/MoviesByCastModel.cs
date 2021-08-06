using System.Collections.Generic;

namespace Forbytes.MovieCatalog.API.ApiModels
{
    public class MoviesByCastApiModel
    {
        public List<MovieApiModel> Movies { get; set; }

        public int Count { get; set; }
    }
}