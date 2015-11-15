namespace SportSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}