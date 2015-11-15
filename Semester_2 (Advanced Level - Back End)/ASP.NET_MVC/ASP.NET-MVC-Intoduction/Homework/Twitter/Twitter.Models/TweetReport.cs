namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TweetReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public string ReporterId { get; set; }

        public virtual User Reporter { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        
    }
}