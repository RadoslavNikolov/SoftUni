namespace Orders.Models
{
    using System;
    using Data;
    using Interfaces;

    public class Order : ICalculatable
    {
        private int id;
        private int productId;
        private Product product;
        private int quantity;
        private decimal discount;

        public Order(int id, int productId, int quantity, decimal discount)
        {
            this.id = id;
            this.productId = productId;
            this.product = Database.DataTools.GetProductById(productId);
            this.quantity = quantity;
            this.discount = discount;
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


        public int ProductId
        {
            get { return this.productId; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Product id must be greater than 0");
                }

                this.productId = value;
            }
        }

        public Product Product
        {
            get { return this.product; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Product cannot be null");
                }

                this.product = value;
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Quantity cannot be negative");
                }

                this.quantity = value;
            }
        }

        public decimal Discount
        {
            get { return this.discount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Discount cannot be negative");
                }

                this.discount = value;
            }
        }

        public decimal CalculateOrderPrice()
        {
            decimal price = 0m;
            price = this.Product.UnitPrice * this.Quantity;
            price -= this.Discount;

            return price;
        }
    }
}