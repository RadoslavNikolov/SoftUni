namespace BuhtigIssueTracker.Utils
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public static class HashUtils
    {
        public static string HashPassword(string password)
        {
            return string.Join
                (string.Empty, SHA1.Create()
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(x => x.ToString()));
        }
    }
}