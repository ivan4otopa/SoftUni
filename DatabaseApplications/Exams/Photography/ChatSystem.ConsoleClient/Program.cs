namespace ChatSystem.ConsoleClient
{
    using Data;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new ChatSystemContext();

            //6.ListAllChannelsWithTheirMessages
            //var channels = context.Channels
            //    .Select(c => new
            //    {
            //        c.Name,
            //        Messages = c.ChannelMessages
            //            .Select(cm => new 
            //            {
            //                cm.Content,
            //                cm.DateTime,
            //                User = cm.User.Username
            //            })
            //    });

            //foreach (var channel in channels)
            //{
            //    Console.WriteLine("{0}\n--Messages:--", channel.Name);

            //    foreach (var message in channel.Messages)
            //    {
            //        Console.WriteLine("Content: {0}, DateTime: {1}, User: {2}", message.Content, message.DateTime, message.User);
            //    }

            //    Console.WriteLine();
            //}

            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var json = File.ReadAllText("../../messages.json");
            dynamic messages = JsonConvert.DeserializeObject(json, settings);

            foreach (var message in messages)
            {
                if (message.content == null)
                {
                    Console.WriteLine("Error: Content is required");

                    continue;
                }


                if (message.datetime == null)
                {
                    Console.WriteLine("Error: DateTime is required");

                    continue;
                }

                if (message.recipient == null)
                {
                    Console.WriteLine("Error: Recipient is required");

                    continue;
                }

                if (message.sender == null)
                {
                    Console.WriteLine("Error: Sender is required");

                    continue;
                }

                string recipientUsername = message.recipient;
                string senderUsername = message.sender;

                context.UserMessages.Add(new UserMessage()
                {
                    Content = message.content,
                    Datetime = message.datetime,
                    RecipientId = context.Users.Where(u => u.Username == recipientUsername).FirstOrDefault().Id,
                    SenderId = context.Users.Where(u => u.Username == senderUsername).FirstOrDefault().Id
                });

                Console.WriteLine("Message {0} imported", message.content);
            }

            context.SaveChanges();
        }
    }
}