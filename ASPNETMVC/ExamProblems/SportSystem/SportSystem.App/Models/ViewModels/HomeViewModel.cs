namespace SportSystem.App.Models.ViewModels
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }

        public IEnumerable<TeamViewModel> Teams { get; set; }
    }
}