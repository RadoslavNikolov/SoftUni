namespace Snippy.App.Models.ViewModels
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Author { get; set; }

        public SnippetInfoViewModel Snippet { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()             
                .ForMember(src => src.Author, opt => opt.MapFrom(src => src.Author.UserName))
                .ReverseMap();
        }
    }
}