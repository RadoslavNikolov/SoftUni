﻿namespace Laptop.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        public string Model { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Display(Name = "Picture URL")]
        public string PictureUrl { get; set; }
    }
}