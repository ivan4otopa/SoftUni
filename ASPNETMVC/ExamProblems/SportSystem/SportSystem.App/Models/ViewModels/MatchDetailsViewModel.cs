namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class MatchDetailsViewModel
    {
        public int Id { get; set; }

        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public decimal HomeTeamBet { get; set; }

        public decimal AwayTeamBet { get; set; }

        public DateTime DateAndTime { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}