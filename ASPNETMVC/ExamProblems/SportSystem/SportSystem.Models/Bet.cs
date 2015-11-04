namespace SportSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        public int Id { get; set; }

        public decimal HomeTeamBet { get; set; }

        public decimal AwayTeamBet { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int MatchId { get; set; }

        public Match Match { get; set; }
    }
}
