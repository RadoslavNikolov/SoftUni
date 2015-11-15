namespace Messages.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserMessage
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        public User SenderUser { get; set; }

        [Required]
        public User RecipientUser { get; set; }
    }
}
