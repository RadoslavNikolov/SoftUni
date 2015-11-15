namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TweetFavorite
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Tweetid { get; set; }

        public Tweet Tweet { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}