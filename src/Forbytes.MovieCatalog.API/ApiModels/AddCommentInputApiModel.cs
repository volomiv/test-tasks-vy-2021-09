namespace Forbytes.MovieCatalog.API.ApiModels
{
    public class AddCommentInputApiModel
    {
        public string MovieId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Comment { get; set; }
    }
}