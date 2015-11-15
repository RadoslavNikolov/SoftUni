namespace BookShop_Web_API.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using BookShopSystem.Models;

    public class PurchaseViewModel
    {

        public PurchaseViewModel(Purchase purchase)
        {
            this.Id = purchase.Id;
            this.BookTitle = purchase.Book.Title;
            this.Price = purchase.Price;
            this.DateOfPurchase = purchase.DateOfPurchase;
            this.IsRecalled = purchase.IsRecalled;
        }

        public int Id { get; set; }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }
    }
}