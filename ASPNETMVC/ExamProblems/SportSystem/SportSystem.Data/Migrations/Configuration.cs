namespace SportSystem.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportSystem.Data.SportSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SportSystem.Data.SportSystemContext";
        }

        protected override void Seed(SportSystem.Data.SportSystemContext context)
        {
            if (context.Teams.Any())
            {
                return;
            }

            context.Teams.Add(new Team()
            {
                Name = "Manchester United F.C.",
                NickName = "The Red Devils",
                WebSite = "http://www.manutd.com",
                DateFounded = new DateTime(1878, 6, 1)
            });
            context.Teams.Add(new Team()
            {
                Name = "Real Madrid",
                NickName = "The Whites",
                WebSite = "http://www.realmadrid.com",
                DateFounded = new DateTime(1902, 3, 6)
            });
            context.Teams.Add(new Team()
            {
                Name = "FC Barcelona",
                NickName = "Barca",
                WebSite = "http://www.fcbarcelona.com",
                DateFounded = new DateTime(1899, 11, 12)
            });
            context.Teams.Add(new Team()
            {
                Name = "Bayern Munich",
                NickName = "The Bavarians",
                WebSite = "http://www.fcbayern.de",
                DateFounded = new DateTime(1900, 2, 13)
            });
            context.Teams.Add(new Team()
            {
                Name = "Manchester City",
                NickName = "The Citizens",
                WebSite = "http://www.mcfc.com",
                DateFounded = new DateTime(1880, 5, 1)
            });
            context.Teams.Add(new Team()
            {
                Name = "Chelsea",
                NickName = "The Pensioners",
                WebSite = "https://www.chelseafc.com",
                DateFounded = new DateTime(1905, 3, 10)
            });
            context.Teams.Add(new Team()
            {
                Name = "Arsenal",
                NickName = "The Gunners",
                WebSite = "http://www.arsenal.com",
                DateFounded = new DateTime(1886, 9, 1)
            });
            context.SaveChanges();
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Real Madrid"),
                AwayTeam = context.Teams.First(t => t.Name == "Manchester United F.C."),
                DateAndTime = new DateTime(2015, 6, 13)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Bayern Munich"),
                AwayTeam = context.Teams.First(t => t.Name == "Manchester United F.C."),
                DateAndTime = new DateTime(2015, 6, 14)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "FC Barcelona"),
                AwayTeam = context.Teams.First(t => t.Name == "Manchester City"),
                DateAndTime = new DateTime(2015, 6, 15)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.First(t => t.Name == "FC Barcelona"),
                DateAndTime = new DateTime(2015, 6, 16)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Real Madrid"),
                AwayTeam = context.Teams.First(t => t.Name == "Manchester City"),
                DateAndTime = new DateTime(2015, 6, 17)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Manchester United F.C."),
                AwayTeam = context.Teams.First(t => t.Name == "Chelsea"),
                DateAndTime = new DateTime(2015, 6, 18)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Arsenal"),
                AwayTeam = context.Teams.First(t => t.Name == "Bayern Munich"),
                DateAndTime = new DateTime(2015, 6, 12)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.First(t => t.Name == "Real Madrid"),
                DateAndTime = new DateTime(2015, 6, 11)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.First(t => t.Name == "Manchester City"),
                DateAndTime = new DateTime(2015, 6, 10)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.First(t => t.Name == "Arsenal"),
                DateAndTime = new DateTime(2015, 6, 19)
            });
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.First(t => t.Name == "Arsenal"),
                AwayTeam = context.Teams.First(t => t.Name == "FC Barcelona"),
                DateAndTime = new DateTime(2015, 6, 20)
            });
            context.Players.Add(new Player()
            {
                Name = "Alexis Sanchez",
                DateOfBirth = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.First(t => t.Name == "FC Barcelona")
            });
            context.Players.Add(new Player()
            {
                Name = "Arjen Robben",
                DateOfBirth = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.First(t => t.Name == "Real Madrid")
            });
            context.Players.Add(new Player()
            {
                Name = "Franck Ribery",
                DateOfBirth = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.First(t => t.Name == "Manchester United F.C.")
            });
            context.Players.Add(new Player()
            {
                Name = "Wayne Rooney",
                DateOfBirth = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.First(t => t.Name == "Manchester United F.C.")
            });
            context.Players.Add(new Player()
            {
                Name = "Lionel Messi",
                DateOfBirth = new DateTime(1982, 1, 13),
                Height = 1.65,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Theo Walcott",
                DateOfBirth = new DateTime(1983, 2, 17),
                Height = 1.75,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Cristiano Ronaldo",
                DateOfBirth = new DateTime(1983, 3, 16),
                Height = 1.85,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Aaron Lennon",
                DateOfBirth = new DateTime(1985, 4, 15),
                Height = 1.95,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Gareth Bale",
                DateOfBirth = new DateTime(1986, 5, 14),
                Height = 1.90,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Antonio Valencia",
                DateOfBirth = new DateTime(1987, 5, 23),
                Height = 1.82,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Robin van Persie",
                DateOfBirth = new DateTime(1988, 6, 13),
                Height = 1.84,
                TeamId = null
            });
            context.Players.Add(new Player()
            {
                Name = "Ronaldinho",
                DateOfBirth = new DateTime(1989, 7, 30),
                Height = 1.87,
                TeamId = null
            });
            context.SaveChanges();

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var alex = new User()
            {
                Email = "alex@usa.net",
                UserName = "alex@usa.net"
            };
            var tanya = new User()
            {
                Email = "tanya@gmail.com",
                UserName = "tanya@gmail.com"
            };

            userManager.Create(alex, "12qw!@QW");
            userManager.Create(tanya, "P@ssWORD!123");
            context.Comments.Add(new Comment()
            {
                Content = "The best match this summer!",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                Owner = context.Users.First(u => u.Email == "alex@usa.net")
            });
            context.Comments.Add(new Comment()
            {
                Content = "The good football this evening.",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                Owner = context.Users.First(u => u.Email == "tanya@gmail.com")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Barca!",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "FC Barcelona" && m.AwayTeam.Name == "Manchester City"),
                Owner = context.Users.First(u => u.Email == "tanya@gmail.com")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Real forever!",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "Real Madrid" && m.AwayTeam.Name == "Manchester City"),
                Owner = context.Users.First(u => u.Email == "alex@usa.net")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Real, real, real",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "Real Madrid" && m.AwayTeam.Name == "Manchester City"),
                Owner = context.Users.First(u => u.Email == "alex@usa.net")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Real again :)",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "Real Madrid" && m.AwayTeam.Name == "Manchester City"),
                Owner = context.Users.First(u => u.Email == "alex@usa.net")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Chelsea champion!",
                DateAndTime = DateTime.Now,
                Match = context.Matches.First(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "Real Madrid"),
                Owner = context.Users.First(u => u.Email == "tanya@gmail.com")
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 30.00M,
                AwayTeamBet = 0,
                User = context.Users.First(u => u.Email == "alex@usa.net"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 0,
                AwayTeamBet = 50.00M,
                User = context.Users.First(u => u.Email == "alex@usa.net"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 0,
                AwayTeamBet = 120.00M,
                User = context.Users.First(u => u.Email == "alex@usa.net"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 120.00M,
                AwayTeamBet = 0,
                User = context.Users.First(u => u.Email == "alex@usa.net"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "FC Barcelona" && m.AwayTeam.Name == "Manchester City"),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 500.00M,
                AwayTeamBet = 0,
                User = context.Users.First(u => u.Email == "alex@usa.net"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 50.00M,
                AwayTeamBet = 0,
                User = context.Users.First(u => u.Email == "tanya@gmail.com"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 0,
                AwayTeamBet = 20.00M,
                User = context.Users.First(u => u.Email == "tanya@gmail.com"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
            });
            context.Bets.Add(new Bet()
            {
                HomeTeamBet = 0,
                AwayTeamBet = 220.00M,
                User = context.Users.First(u => u.Email == "tanya@gmail.com"),
                Match = context.Matches.First(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
            });
            context.Votes.Add(new Vote()
            {
                Team = context.Teams.First(t => t.Name == "Bayern Munich"),
                User = context.Users.First(u => u.Email == "tanya@gmail.com")
            });
            context.Votes.Add(new Vote()
            {
                Team = context.Teams.First(t => t.Name == "Real Madrid"),
                User = context.Users.First(u => u.Email == "tanya@gmail.com")
            });
            context.Votes.Add(new Vote()
            {
                Team = context.Teams.First(t => t.Name == "Bayern Munich"),
                User = context.Users.First(u => u.Email == "alex@usa.net")
            });
            context.SaveChanges();
        }
    }
}
