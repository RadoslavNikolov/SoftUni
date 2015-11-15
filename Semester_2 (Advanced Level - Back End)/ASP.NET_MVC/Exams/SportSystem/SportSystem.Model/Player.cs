namespace SportSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public double Height { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}