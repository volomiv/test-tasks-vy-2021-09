using AutoMapper;
using Forbytes.MovieCatalog.AppServices.Models;

namespace Forbytes.MovieCatalog.AppServices.ModelProfiles
{
    internal class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Repositories.Data.Models.Comment, CommentModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.MovieId, o => o.MapFrom(s => s.MovieId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Text, o => o.MapFrom(s => s.Text))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.UpdatedAt));

            CreateMap<Repositories.Data.Projections.IdCountProjection, IdCountModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.Count));

            CreateMap<Repositories.Data.Projections.TopCommentersProjection, TopCommentersModel>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
        }
    }
}