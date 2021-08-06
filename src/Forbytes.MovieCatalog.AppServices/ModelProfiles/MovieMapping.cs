using AutoMapper;
using Forbytes.MovieCatalog.AppServices.Models;

namespace Forbytes.MovieCatalog.AppServices.ModelProfiles
{
    internal class MovieMapping : Profile
    {
        public MovieMapping()
        {
            CreateMap<Repositories.Data.Models.Movie, MovieModel>();

            CreateMap<Repositories.Data.Models.Awards, AwardsModel>()
                .ForMember(d => d.Wins, o => o.MapFrom(s => s.Wins))
                .ForMember(d => d.Nominations, o => o.MapFrom(s => s.Nominations))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text));

            CreateMap<Repositories.Data.Models.Imdb, ImdbModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ImdbId))
                .ForMember(d => d.Votes, o => o.MapFrom(s => s.Votes))
                .ForMember(d => d.Rating, o => o.MapFrom(s => s.Rating));

            CreateMap<Repositories.Data.Projections.MoviesByCastProjection, MoviesByCastModel>()
                .ForMember(d => d.Movies, o => o.MapFrom(s => s.Movies))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.Count));
        }
    }
}