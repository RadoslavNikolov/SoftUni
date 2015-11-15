namespace SportSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime PostedOn { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}