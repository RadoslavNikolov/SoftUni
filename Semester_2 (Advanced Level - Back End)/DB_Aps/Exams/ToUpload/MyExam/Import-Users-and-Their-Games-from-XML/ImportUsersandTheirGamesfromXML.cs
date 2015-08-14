namespace Import_Users_and_Their_Games_from_XML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Diablo_DataBase_First;

    class ImportUsersandTheirGamesfromXML
    {
        static void Main()
        {

            var context = new DiabloEntities();
            var sourceXml = XDocument.Load(@"../../../users-and-games.xml");
            var usersList = sourceXml.XPathSelectElements("/users/user");



            foreach (var xUser in usersList)
            {

                var userName = xUser.Attribute("username");
                int isDeleted = (int) xUser.Attribute("is-deleted");
                if (userName == null)
                {
                    Console.WriteLine("Username is mandatory!");
                    continue;
                }
                if (isDeleted == 1)
                {
                    continue;
                }

                User user = null;
                user = context.Users.FirstOrDefault(u => u.Username == (string) userName);

                if (user != null)
                {
                    Console.WriteLine("User {0} already exists", user.Username);
                }
                else
                {
                    var firstName = xUser.Attribute("first-name");
                    var lastName = xUser.Attribute("last-name");
                    var eMail = xUser.Attribute("email");
                    var ipAddress = xUser.Attribute("ip-address");
                    var registrationDate = DateTime.Parse((string) xUser.Attribute("registration-date"));

                    user = new User()
                    {
                        Username = (string) userName,
                        FirstName = (string) firstName,
                        LastName = (string) lastName,
                        Email = (string) eMail,
                        IpAddress = (string) ipAddress,
                        RegistrationDate = registrationDate
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                    Console.WriteLine("Successfully added user {0}", user.Username);

                    AddUserToGame(user, xUser, context);
                }

            }
        }

        private static void AddUserToGame(User user, XElement xUser, DiabloEntities context)
        {


        }
    }
}
