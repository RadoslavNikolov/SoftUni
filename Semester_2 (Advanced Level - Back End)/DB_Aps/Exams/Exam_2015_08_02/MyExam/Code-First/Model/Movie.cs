namespace Code_First
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Model;

    public class Movie
    {
        private ICollection<User> users;
        private ICollection<Rating> ratingses;

        public Movie()
        {
            this.users = new HashSet<User>();
            this.ratingses = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Titlee must be 100 characters or less")] 
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Rating> Ratingses
        {
            get { return this.ratingses; }
            set { this.ratingses = value; }
        }
    }
}