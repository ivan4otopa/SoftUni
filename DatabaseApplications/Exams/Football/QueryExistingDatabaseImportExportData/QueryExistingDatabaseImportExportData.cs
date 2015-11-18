namespace QueryExistingDatabaseImportExportData
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class QueryExistingDatabaseImportExportData
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();

            //1.EntityFrameworkMappings
            //var teams = context.Teams
            //    .Select(t => t.TeamName);

            //foreach (var teamName in teams)
            //{
            //    Console.WriteLine(teamName);
            //}

            //2.ExportLeaguesAndTeamsAsJSON
            //var leaguesTeams = context.Leagues
            //    .OrderBy(l => l.LeagueName)
            //    .Select(l => new
            //    {
            //        leagueName = l.LeagueName,
            //        teams = l.Teams
            //            .OrderBy(t => t.TeamName)
            //            .Select(t => t.TeamName)
            //    });
            //string json = JsonConvert.SerializeObject(leaguesTeams, Formatting.Indented);
            //File.WriteAllText("../../leagues-and-teams.json", json);

            //3.ExportInternationalMatchesAsXML
            //var internationalMatches = context.InternationalMatches
            //    .OrderBy(im => im.MatchDate)
            //    .ThenBy(im => im.HomeCountry.CountryName)
            //    .ThenBy(im => im.AwayCountry.CountryName);

            //XmlWriterSettings settings = new XmlWriterSettings()
            //{
            //    Indent = true,
            //    NewLineChars = "\n"
            //};

            //using (XmlWriter writer = XmlWriter.Create("../../international-matches.xml", settings))
            //{
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("matches");

            //    foreach (var match in internationalMatches)
            //    {
            //        writer.WriteStartElement("match");

            //        if (match.MatchDate != null)
            //        {
            //            if (match.MatchDate.Value.TimeOfDay.TotalSeconds != 0)
            //            {
            //                writer.WriteAttributeString("date-time", match.MatchDate.Value.ToString("d-MMM-yyyy hh:mm"));
            //            }
            //            else
            //            {
            //                writer.WriteAttributeString("date", match.MatchDate.Value.ToString("d-MMM-yyyy"));
            //            }    
            //        }

            //        writer.WriteStartElement("home-country");
            //        writer.WriteAttributeString("code", match.HomeCountryCode);
            //        writer.WriteString(match.HomeCountry.CountryName);
            //        writer.WriteEndElement();
            //        writer.WriteStartElement("away-country");
            //        writer.WriteAttributeString("code", match.AwayCountryCode);
            //        writer.WriteString(match.AwayCountry.CountryName);
            //        writer.WriteEndElement();

            //        if (match.HomeGoals != null)
            //        {
            //            writer.WriteStartElement("score");
            //            writer.WriteString(string.Format("{0}-{1}", match.HomeGoals, match.AwayGoals));
            //            writer.WriteEndElement();
            //        }

            //        if (match.League != null)
            //        {
            //            writer.WriteStartElement("league");
            //            writer.WriteString(match.League.LeagueName);
            //            writer.WriteEndElement();
            //        }

            //        writer.WriteEndElement();
            //    }

            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}

            //4.ImportLeaguesAndTeamsFromXML
            var xmlDocument = XDocument.Load("../../leagues-and-teams.xml");
            var leagues =
                from league in xmlDocument.Descendants("league")
                select new 
                {
                    LeagueName = league.Element("league-name") == null ? null : league.Element("league-name").Value,
                    Teams = league.Descendants("teams") == null ? null :
                        from team in league.Descendants("team")
                        select new
                        {
                            Name = team.Attribute("name").Value,
                            CountryName = team.Attribute("country") == null ? null : team.Attribute("country").Value
                        }
                };
            int leagueNumber = 1;

            foreach (var league in leagues)
            {
                Console.WriteLine("Processing league #{0} ...", leagueNumber);

                if (league.LeagueName != null)
                {
                    LeagueExistanceCheck(context, league.LeagueName);
                }

                foreach (var team in league.Teams)
                {
                    TeamExistanceCheck(context, team.Name, team.CountryName);
                    TeamInLeagueExistanceCheck(context, league.LeagueName, team.CountryName, team.Name);
                }

                Console.WriteLine();
                leagueNumber++;
            }
        }

        static void LeagueExistanceCheck(FootballEntities context, string leagueName)
        {
            if (!context.Leagues.Any(l => l.LeagueName == leagueName))
            {
                context.Leagues.Add(new League()
                {
                    LeagueName = leagueName
                });
                context.SaveChanges();
                Console.WriteLine("Created league: {0}", leagueName);
            }
            else
            {
                Console.WriteLine("Existing league: {0}", leagueName);
            }
        }

        static void TeamExistanceCheck(FootballEntities context, string teamName, string countryName)
        {
            if (!context.Teams.Any(t => t.TeamName == teamName && t.Country.CountryName == countryName))
            {
                context.Teams.Add(new Team()
                {
                    TeamName = teamName,
                    Country = context.Countries.Where(c => c.CountryName == countryName).FirstOrDefault()
                });
                context.SaveChanges();
                Console.WriteLine("Created team: {0} ({1})", teamName,
                    (countryName == null ? "no country" : countryName));
            }
            else
            {
                Console.WriteLine("Existing team: {0} ({1})", teamName,
                    (countryName == null ? "no country" : countryName));
            }
        }

        static void TeamInLeagueExistanceCheck(FootballEntities context, string leagueName, string teamCountryName, string teamName)
        {
            var currentLeague = context.Leagues.Where(l => l.LeagueName == leagueName).FirstOrDefault();

            if (currentLeague != null)
            {
                if (teamCountryName != null)
                {
                    if (!currentLeague.Teams.Any(t => t.TeamName == teamName && t.Country.CountryName == teamCountryName))
                    {
                        currentLeague.Teams.Add(
                            context.Teams.Where(t => t.TeamName == teamName && t.Country.CountryName == teamCountryName).FirstOrDefault());
                        Console.WriteLine("Added team to league: {0} to league {1}", teamName, leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing team in league: {0} belongs to {1}", teamName, leagueName);
                    }
                }
                else
                {
                    if (!currentLeague.Teams.Any(t => t.TeamName == teamName))
                    {
                        currentLeague.Teams.Add(
                            context.Teams.Where(t => t.TeamName == teamName).FirstOrDefault()); 
                        context.SaveChanges();
                        Console.WriteLine("Added team to league: {0} to league {1}", teamName, leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing team in league: {0} belongs to {1}", teamName, leagueName);
                    }
                }
            }
        }
    }
}