namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Model;

    public class MatchViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Display(Name = "Home Team")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        public string AwayTeam { get; set; }

        public DateTime StartDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchViewModel>()
                .ForMember(n => n.HomeTeam, opt => opt.MapFrom(n => n.HomeTeam.Name))
                .ForMember(n => n.AwayTeam, opt => opt.MapFrom(n => n.AwayTeam.Name))
                .ReverseMap();
        }
    }
}