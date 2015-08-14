namespace Code_First.Model
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Movie> movies;
        private ICollection<Rating> ratingses;


        public User()
        {
            this.movies = new HashSet<Movie>();
            this.ratingses = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage="UserName name must be at least 5 characters")]

        public string UserName { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }

        public virtual ICollection<Rating> Ratingses
        {
            get { return this.ratingses; }
            set { this.ratingses = value; }
        }

        //public virtual ICollection<Country> Countries { get; set; }
    }
}