namespace ShopSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        private ICollection<Category> categories;

        public Product()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }


        [ForeignKey("Seller")]
        public int? SellerId { get; set; }

        [ForeignKey("Buyer")]
        public int? BuyerId { get; set; }

        [InverseProperty("SoldProduct")]
        public virtual User Seller { get; set; }

        [InverseProperty("BoughtProduct")]
        public virtual User Buyer { get; set; }

        public ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

    }
}