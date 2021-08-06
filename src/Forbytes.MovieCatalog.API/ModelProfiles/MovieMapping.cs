using AutoMapper;
using Forbytes.MovieCatalog.API.ApiModels;
using Forbytes.MovieCatalog.AppServices.Models;

namespace Forbytes.MovieCatalog.API.ModelProfiles
{
    internal class MovieMapping : Profile
    {
        public MovieMapping()
        {
            CreateMap<MovieModel, MovieApiModel>();

            CreateMap<AwardsModel, AwardsApiModel>()
                .ForMember(d => d.Wins, o => o.MapFrom(s => s.Wins))
                .ForMember(d => d.Nominations, o => o.MapFrom(s => s.Nominations))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text));

            CreateMap<ImdbModel, ImdbApiModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Votes, o => o.MapFrom(s => s.Votes))
                .ForMember(d => d.Rating, o => o.MapFrom(s => s.Rating));

            CreateMap<MoviesByCastModel, MoviesByCastApiModel>()
                .ForMember(d => d.Movies, o => o.MapFrom(s => s.Movies))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.Count));
        }
    }
}