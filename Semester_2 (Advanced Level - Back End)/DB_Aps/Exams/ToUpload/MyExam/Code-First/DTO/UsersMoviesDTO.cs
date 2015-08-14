namespace Code_First.DTO
{
    using System.Collections.Generic;

    public class UsersMoviesDto
    {
        public string Username { get; set; }

        public List<string> FavouriteMovies { get; set; } 
    }
}