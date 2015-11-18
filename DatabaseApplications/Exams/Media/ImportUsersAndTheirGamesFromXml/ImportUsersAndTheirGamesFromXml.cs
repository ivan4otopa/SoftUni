namespace ImportUsersAndTheirGamesFromXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using EntityFrameworkMappings;

    class ImportUsersAndTheirGamesFromXml
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var xmlDocument = XDocument.Load("../../users-and-games.xml");
            var users =
                from user in xmlDocument.Descendants("user")
                select new
                {
                    FirstName = user.Attribute("first-name") == null ? null : user.Attribute("first-name").Value,
                    LastName = user.Attribute("last-name") == null ? null : user.Attribute("last-name").Value,
                    Username = user.Attribute("username").Value,
                    Email = user.Attribute("email") == null ? null : user.Attribute("email").Value,
                    IsDeleted = byte.Parse(user.Attribute("is-deleted").Value) == 0 ? false : true,
                    IpAddress = user.Attribute("ip-address").Value,
                    RegistrationDate = new DateTime(int.Parse(user.Attribute("registration-date").Value.Split('/')[2]),
                        int.Parse(user.Attribute("registration-date").Value.Split('/')[1]),
                        int.Parse(user.Attribute("registration-date").Value.Split('/')[0])),
                    Games =
                        from game in user.Descendants("game")
                        select new
                        {
                            GameName = game.Element("game-name").Value,
                            CharacterName = game.Element("character").Attribute("name").Value,
                            Cash = decimal.Parse(game.Element("character").Attribute("cash").Value),
                            Level = int.Parse(game.Element("character").Attribute("level").Value),
                            JoinedOn = new DateTime(int.Parse(game.Element("joined-on").Value.Split('/')[2]),
                                int.Parse(game.Element("joined-on").Value.Split('/')[1]),
                                int.Parse(game.Element("joined-on").Value.Split('/')[0]))
                        }
                };

            foreach (var user in users)
            {
                if (!context.Users.Any(u => u.Username == user.Username))
                {
                    context.Users.Add(new User()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Email = user.Email,
                        IsDeleted = user.IsDeleted,
                        IpAddress = user.IpAddress,
                        RegistrationDate = user.RegistrationDate
                    });
                    context.SaveChanges();
                    Console.WriteLine("Successfully added user {0}", user.Username);

                    foreach (var game in user.Games)
                    {
                        context.UsersGames.Add(new UsersGame()
                        {
                            GameId = context.Games.Where(g => g.Name == game.GameName).FirstOrDefault().Id,
                            UserId = context.Users.Where(u => u.Username == user.Username).FirstOrDefault().Id,
                            CharacterId = context.Characters.Where(c => c.Name == game.CharacterName).FirstOrDefault().Id,
                            Level = game.Level,
                            JoinedOn = game.JoinedOn,
                            Cash = game.Cash
                        });
                        Console.WriteLine("User {0} successfully added to game {1}", user.Username, game.GameName);
                    }
                }
                else
                {
                    Console.WriteLine("User {0} already exists", user.Username);
                }
            }

            context.SaveChanges();
        }
    }
}
