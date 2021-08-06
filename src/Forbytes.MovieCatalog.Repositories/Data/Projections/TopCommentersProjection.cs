using System.Collections.Generic;

namespace Forbytes.MovieCatalog.Repositories.Data.Projections
{
    public class TopCommentersProjection
    {
        public List<IdCountProjection> Items { get; set; }
    }
}