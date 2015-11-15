namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}