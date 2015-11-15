namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Model;

    public class TeamViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }

        public int Votes { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(src => src.Votes, opt => opt.MapFrom(src => src.Votes.Any() ? src.Votes.Sum(v => v.Value) : 0))
                .ReverseMap();
        }
    }
}