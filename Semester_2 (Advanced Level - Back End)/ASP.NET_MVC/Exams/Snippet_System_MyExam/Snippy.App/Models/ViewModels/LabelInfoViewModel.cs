namespace Snippy.App.Models.ViewModels
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using Snippy.Models;

    public class LabelInfoViewModel : IMapFrom<Label>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SnippetsCount { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Label, LabelInfoViewModel>()
                .ForMember(src => src.SnippetsCount, opt => opt.MapFrom(src => src.Snippets.Count))
                .ReverseMap();
        }
    }
}