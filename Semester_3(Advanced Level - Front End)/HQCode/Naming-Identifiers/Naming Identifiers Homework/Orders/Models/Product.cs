namespace Orders.Models
{
    using System;
    using Data;

    public class Product
    {
        private int id;
        private string name;
        private Category category;
        private decimal unitPrice;
        private int unitsInStock;

        public Product(int id, string name, int catId, decimal unitPrice, int unitsInStock)
        {
            this.Id = id;
            this.Name = name;
            this.Category = Database.DataTools.GetCategoryById(catId);
            this.unitPrice = unitPrice;
            this.unitsInStock = unitsInStock;
            this.CatId = catId;
        }


        public int Id
        {
            get { return this.id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Id must be greater than 0");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Category name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int CatId { get;private set; }

        public Category Category
        {
            get { return this.category; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Category cannot be null");
                }

                this.category = value;
            }
        }

        public decimal UnitPrice
        {
            get { return this.unitPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Unit price cannot be negative");
                }

                this.unitPrice = value;
            }
        }

        public int UnitsInStock
        {
            get { return this.unitsInStock; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Unit in stock cannot be negative");
                }

                this.unitsInStock = value;
            }
        }
    }
}