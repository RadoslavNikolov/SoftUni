namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {

        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Tweet> ownTweets;
        private ICollection<Tweet> wallTweets;
        private ICollection<TweetFavorite> favouriteTweets;
        private ICollection<Message> sendedMessages;
        private ICollection<Message> receivedMessages;
        private ICollection<TweetReport> tweeteReports;
        private ICollection<File> files; 

        public User()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.ownTweets = new HashSet<Tweet>();
            this.wallTweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<TweetFavorite>();
            this.sendedMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.tweeteReports = new HashSet<TweetReport>();
            this.files = new HashSet<File>();
        }

        public string ProfilePictureUrl { get; set; }

        public virtual ICollection<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public virtual ICollection<TweetReport> TweeteReports
        {
            get { return this.tweeteReports; }
            set { this.tweeteReports = value; }
        }

        public virtual ICollection<Message> SendedMessages
        {
            get { return this.sendedMessages; }
            set { this.sendedMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        public virtual ICollection<TweetFavorite> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> Following
        {
            get { return this.following; }
            set { this.following = value; }
        }

        public virtual ICollection<Tweet> OwnTweets
        {
            get { return this.ownTweets; }
            set { this.ownTweets = value; }
        }

        public virtual ICollection<Tweet> WallTweets
        {
            get { return this.wallTweets; }
            set { this.wallTweets = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}