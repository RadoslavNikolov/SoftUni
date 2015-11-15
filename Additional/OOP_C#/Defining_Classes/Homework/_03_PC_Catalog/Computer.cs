using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    public class Computer
    {
        private string name;
        private List<Component> components = new List<Component>();
        //private decimal totalPrice;

        public Computer(string name, params Component[] list)
        {
            this.Name = name;
            this.AddComponents(list);
        }

        public void AddComponents(params Component[] list)
        {
            foreach (Component component in list.Where(component => component != null))
            {
                this.components.Add(component);
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Computer name cannot be empty!");
                }
                this.name = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0m;
                foreach (Component component in components)
                {
                    totalPrice += component.Price;
                }
                return totalPrice;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Model: {0}\n", this.Name);
            foreach (Component component in components)
            {
                result += component;
            }
            result += string.Format("\nTotal Price: {0:F2} BGN\n", this.TotalPrice);
            return result;
        }
    }
}
