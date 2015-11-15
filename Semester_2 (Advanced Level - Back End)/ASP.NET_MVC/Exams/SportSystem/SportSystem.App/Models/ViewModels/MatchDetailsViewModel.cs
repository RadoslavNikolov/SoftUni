namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Model;

    public class MatchDetailsViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public int AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public DateTime StartDate { get; set; }

        public decimal HomeBets { get; set; }

        public decimal AwayBets { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchDetailsViewModel>()
                .ForMember(src => src.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.Name))
                .ForMember(src => src.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.Name))
                .ForMember(src => src.HomeBets,
                    opt => opt.MapFrom(src => src.UserMatchBets.Any() ? src.UserMatchBets.Sum(b => b.HomeBet) : 0))
                .ForMember(src => src.AwayBets,
                    opt => opt.MapFrom(src => src.UserMatchBets.Any() ? src.UserMatchBets.Sum(b => b.AwayBet) : 0))
                .ReverseMap();
        }
    }
}