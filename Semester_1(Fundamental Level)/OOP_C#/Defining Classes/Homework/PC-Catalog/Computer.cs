namespace PC_Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Computer
    {
        private string name;
        private ICollection<Component> components;
        private decimal totalPrice;

        public Computer(string name)
        {
            this.Name = name;
            this.components = new SortedSet<Component>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Computer name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public decimal TotalPrice
        {
            get { return this.components.Sum(c => c.Price); }
        }

        public ICollection<Component> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }


        public void Print()
        {
            var result = new StringBuilder();
            result.AppendLine($"Computer name: {this.Name}");

            if (this.components.Any())
            {
                foreach (var component in this.components)
                {
                    result.Append(component);
                }
            }

            result.AppendLine($"Total price: {this.TotalPrice:N2} lv.");
            Console.WriteLine(result);
        }

    }
}