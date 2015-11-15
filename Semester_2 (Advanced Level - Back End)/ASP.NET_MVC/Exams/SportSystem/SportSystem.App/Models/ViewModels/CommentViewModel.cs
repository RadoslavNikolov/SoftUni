namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Model;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime PostedOn { get; set; }

        public string Owner { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(src => src.Owner, opt => opt.MapFrom(src => src.Owner.UserName))
                .ReverseMap();
        }
    }
}