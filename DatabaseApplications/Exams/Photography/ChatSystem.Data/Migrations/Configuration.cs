namespace ChatSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChatSystem.Data.ChatSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ChatSystem.Data.ChatSystemContext";
        }

        protected override void Seed(ChatSystem.Data.ChatSystemContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var usernames = new string[] { "VGeorgiev", "Nakov", "Ache", "Alex", "Petya" };
            var fullNames = new string[] 
            {
                "Vladimir Georgiev", 
                "Svetlin Nakov", 
                "Angel Georgiev", 
                "Alexandra Svilarova", 
                "Petya Grozdarska" 
            };
            var phoneNumbers = new string[] { "0894545454", "0897878787", "0897121212", "0894151417", "0895464646" };
            var channelNames = new string[] { "Malinki", "SoftUni", "Admins", "Programmers", "Geeks" };

            for (int i = 0; i < 5; i++)
            {
                context.Users.Add(new User()
                {
                    Username = usernames[i],
                    FullName = fullNames[i],
                    PhoneNumber = phoneNumbers[i]
                });

                context.Channels.Add(new Channel()
                {
                    Name = channelNames[i]
                });
            }

            context.SaveChanges();

            var messages = new string[] 
            { 
                "Hey dudes, are you ready for tonight?",
                "Hey Petya, this is the SoftUni chat.",
                "Hahaha, we are ready!",
                "Oh my god. I mean for drinking beers!",
                "We are sure!"
            };
            var channelId = context.Channels.Where(c => c.Name == "Malinki").FirstOrDefault().Id;
            var userId = 0;

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    userId = 5;
                }
                else if (i == 1)
                {
                    userId = 1;
                }
                else if (i == 2)
                {
                    userId = 2;
                }
                else if (i == 3)
                {
                    userId = 5;
                }
                else if (i == 4)
                {
                    userId = 1;
                }

                context.ChannelMessages.Add(new ChannelMessage()
                {
                    Content = messages[i],
                    DateTime = DateTime.Now,
                    ChannelId = channelId,
                    UserId = userId
                });
            }

            context.SaveChanges();
        }
    }
}
