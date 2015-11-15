namespace SportSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserMatchBet
    {
        [Key]
        public int Id { get; set; }

        public decimal HomeBet { get; set; }

        public decimal AwayBet { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

    }
}