namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public virtual User Receiver { get; set; }
    }
}