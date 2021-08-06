using AutoMapper;
using Forbytes.MovieCatalog.API.ApiModels;
using Forbytes.MovieCatalog.AppServices.Models;

namespace Forbytes.MovieCatalog.API.ModelProfiles
{
    internal class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<CommentModel, CommentApiModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.MovieId, o => o.MapFrom(s => s.MovieId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.UpdatedAt));

            CreateMap<IdCountModel, IdCountApiModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.Count));

            CreateMap<TopCommentersModel, TopCommentersApiModel>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
        }
    }
}