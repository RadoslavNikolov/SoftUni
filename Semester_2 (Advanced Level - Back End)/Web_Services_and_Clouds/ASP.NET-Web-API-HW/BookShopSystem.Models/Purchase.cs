namespace BookShopSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BookShop_Web_API.Models;

    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

    }
}