namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Model;

    public class TeamDetailsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public DateTime? DateFounded { get; set; }

        public string WebSite { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public int Votes { get; set; }

        public bool UserHasVoted { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                .ForMember(src => src.Votes, opt => opt.MapFrom(src => src.Votes.Any() ? src.Votes.Sum(v => v.Value) : 0))
                .ForMember(src => src.UserHasVoted, opt => opt.MapFrom(src => src.Votes.Any(v => v.User.UserName == HttpContext.Current.User.Identity.Name)))
                .ReverseMap();
        }
    }
}