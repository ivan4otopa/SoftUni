namespace SportSystem.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;

    using SportSystem.Models;
    using System.ComponentModel;

    public class TeamDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string NickName { get; set; }
        
        public DateTime DateFounded { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}