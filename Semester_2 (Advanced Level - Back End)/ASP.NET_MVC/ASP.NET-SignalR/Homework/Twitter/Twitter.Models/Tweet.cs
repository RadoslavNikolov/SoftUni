namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<Reply> replies;
        private ICollection<TweetFavorite> favorites;
        private ICollection<TweetReport> tweetReports;
        private ICollection<File> files; 

        public Tweet()
        {
            this.replies = new HashSet<Reply>();
            this.favorites = new HashSet<TweetFavorite>();
            this.tweetReports = new HashSet<TweetReport>();
            this.files = new HashSet<File>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        
        public string Url { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        
        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public string WallOwnerId { get; set; }

        public virtual User WallOwner { get; set; }

        public virtual ICollection<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }


        public virtual ICollection<TweetReport> TweetReports
        {
            get { return this.tweetReports; }
            set { this.tweetReports = value; }
        }

        public virtual ICollection<Reply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }

        public virtual ICollection<TweetFavorite> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }
    }
}