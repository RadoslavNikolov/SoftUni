

namespace ImportUserMessagesFromJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Phonebook.Model;
 
    class Program
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"../../../messages.json");
            //Console.WriteLine(json);
            var jsSerialized = new JavaScriptSerializer();
            var parsedMessages = jsSerialized.Deserialize<IEnumerable<Message>>(json);

            foreach (var message in parsedMessages)
            {
                try
                {
                    ImportNewMessages(message);
                    Console.WriteLine("Message \"{0}\" imported", message.Content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }

        }

        private static void ImportNewMessages(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Content))
            {
                throw new ArgumentException("Content is required");
            }

            if (string.IsNullOrWhiteSpace(message.Recipient))
            {
                throw new ArgumentException("Recipient is required");
            }

            if (string.IsNullOrWhiteSpace(message.Sender))
            {
                throw new ArgumentException("Sender is required");
            }

            var context = new PhonebookModel();

            var senderId = context.Users
                .Where(u => u.UserName == message.Sender)
                .Select(u => u.Id)
                .FirstOrDefault();

            var recipientId = context.Users
                .Where(u => u.UserName == message.Recipient)
                .Select(u => u.Id)
                .FirstOrDefault();

            var newMessage = new UserMessage
            {
                Content = message.Content,
                DateTime = message.DateTime,
                RecipientId = recipientId,
                SenderId = senderId
            };

            context.UserMessages.Add(newMessage);
            context.SaveChanges();
        }
    }
}
