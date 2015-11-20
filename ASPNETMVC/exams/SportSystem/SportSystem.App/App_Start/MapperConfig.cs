namespace SportSystem.App.App_Start
{
    using AutoMapper;

    using Models.ViewModels;

    using SportSystem.Models;
    using System.Linq;

    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Match, MatchViewModel>()
                .ForMember("HomeTeamName", c => c.MapFrom(m => m.HomeTeam.Name))
                .ForMember("AwayTeamName", c => c.MapFrom(m => m.AwayTeam.Name));
            Mapper.CreateMap<Team, TeamViewModel>()
                .ForMember("VotesCount", c => c.MapFrom(t => t.Votes.Count));
            Mapper.CreateMap<Team, TeamDetailsViewModel>()
                .ForMember("VotesCount", c => c.MapFrom(t => t.Votes.Count));
            Mapper.CreateMap<Player, PlayerViewModel>();
            Mapper.CreateMap<Match, MatchDetailsViewModel>()
                .ForMember("HomeTeamName", c => c.MapFrom(m => m.HomeTeam.Name))
                .ForMember("AwayTeamName", c => c.MapFrom(m => m.AwayTeam.Name))
                .ForMember("HomeTeamBet", c => c.MapFrom(m => m.Bets.Sum(b => b.HomeTeamBet)))
                .ForMember("AwayTeamBet", c => c.MapFrom(m => m.Bets.Sum(b => b.AwayTeamBet)));
            Mapper.CreateMap<Comment, CommentViewModel>()
                .ForMember("Owner", c => c.MapFrom(co => co.Owner.UserName));
        }
    }
}