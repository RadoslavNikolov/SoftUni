namespace BuhtigIssueTracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Utils;

    public class User
    {
        public User(string username, string password)
        {
            this.UserName = username;
            this.UserPassword = HashUtils.HashPassword(password);
        }

        public string UserName { get; private set; }

        public string UserPassword { get; private set; }       
    }
}