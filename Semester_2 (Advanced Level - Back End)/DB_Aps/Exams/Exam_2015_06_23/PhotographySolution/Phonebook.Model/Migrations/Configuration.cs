namespace Phonebook.Model.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Phonebook.Model.PhonebookModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(Phonebook.Model.PhonebookModel context)
        {
            AddUsers(context);

            AddChannels(context);

            AddChannelMessages(context);
        }

        private static void AddChannelMessages(PhonebookModel context)
        {
            if (!context.ChannelMessages.Any())
            {
                var channelMalinki = context.Channels.FirstOrDefault(c => c.Name == "Malinki");
                var petya = context.Users.FirstOrDefault(u => u.UserName == "Petya");
                var vlado = context.Users.FirstOrDefault(u => u.UserName == "VGeorgiev");
                var nakov = context.Users.FirstOrDefault(u => u.UserName == "Nakov");

                var messages = new List<ChannelMessage>
                {
                    new ChannelMessage
                    {
                        ChannelId = channelMalinki.Id,
                        Content = "Hey dudes, are you ready for tonight?",
                        DateTime = DateTime.Now,
                        UserId = petya.Id
                    },
                    new ChannelMessage
                    {
                        ChannelId = channelMalinki.Id,
                        Content = "Hey Petya, this is the SoftUni chat",
                        DateTime = DateTime.Now,
                        UserId = vlado.Id
                    },
                    new ChannelMessage
                    {
                        ChannelId = channelMalinki.Id,
                        Content = "Hahaha, we are ready!",
                        DateTime = DateTime.Now,
                        UserId = nakov.Id
                    },
                    new ChannelMessage
                    {
                        ChannelId = channelMalinki.Id,
                        Content = "Hahaha, we are ready!",
                        DateTime = DateTime.Now,
                        UserId = petya.Id
                    },
                    new ChannelMessage
                    {
                        ChannelId = channelMalinki.Id,
                        Content = "We are sure!",
                        DateTime = DateTime.Now,
                        UserId = vlado.Id
                    }
                };

                messages.ForEach(m => { context.ChannelMessages.Add(m); });

                context.SaveChanges();
            }
        }

        private static void AddChannels(PhonebookModel context)
        {
            if (!context.Channels.Any())
            {
                var channels = new List<Channel>
                {
                    new Channel {Name = "Malinki"},
                    new Channel {Name = "SoftUni"},
                    new Channel {Name = "Admins"},
                    new Channel {Name = "Programmers"},
                    new Channel {Name = "Geeks"}
                };

                channels.ForEach(c => { context.Channels.Add(c); });

                context.SaveChanges();
            }
        }

        private static void AddUsers(PhonebookModel context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User {UserName = "VGeorgiev", FullName = "Vladimir Georgiev", PhoneNumber = "0894545454"},
                    new User {UserName = "Nakov", FullName = "Svetlin Nakov", PhoneNumber = "0897878787"},
                    new User {UserName = "Ache", FullName = "Angel Georgiev", PhoneNumber = "0897121212"},
                    new User {UserName = "Alex", FullName = "Alexandra Svilarova", PhoneNumber = "0894151417"},
                    new User {UserName = "Petya", FullName = "Petya Grozdarska", PhoneNumber = "0895464646"}
                };
                users.ForEach(u => { context.Users.Add(u); });

                context.SaveChanges();
            }
        }
    }
}
