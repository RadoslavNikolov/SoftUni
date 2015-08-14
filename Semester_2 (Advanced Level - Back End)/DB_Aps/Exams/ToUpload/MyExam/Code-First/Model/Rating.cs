﻿namespace Code_First.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rating
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        [Index("IX_UserAndMovie", 1, IsUnique = true)]
        public int UserId { get; set; }

        public virtual User Users { get; set; }

        [Index("IX_UserAndMovie", 2, IsUnique = true)]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

    }
}