namespace Phonebook.Model
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new PhonebookModel();
            var channels = context.Channels.ToList();

            channels.ForEach(c =>
            {
                Console.WriteLine(c.Name);
                Console.WriteLine("\n--Messages--\n");
                foreach (var channelMessage in c.ChannelMessages)
                {
                    Console.WriteLine("Contetnt: {0}, DateTime: {1:}, User: {2}",
                        channelMessage.Content, string.Format(CultureInfo.InvariantCulture,"{0:M/d/yyyy h:mm:ss tt}",channelMessage.DateTime), channelMessage.User.UserName);
                }
                Console.WriteLine("\n\n");
            });
        } 
    }
}