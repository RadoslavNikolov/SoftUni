namespace PC_Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Component : IComparable<Component>
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Component name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Component details cannot be empty");
                }

                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Component price cannot be negative");
                }

                this.price = value;
            }
        }

        public int CompareTo(Component other)
        {
            if (this.Price == other.Price)
            {
                return String.Compare(this.Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Component name: {this.Name}  with price: {this.Price:N2} lv.");
            return result.ToString();
        }


    }
}