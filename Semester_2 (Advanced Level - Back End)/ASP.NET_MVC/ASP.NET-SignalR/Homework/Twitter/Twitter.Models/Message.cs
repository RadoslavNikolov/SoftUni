﻿namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}