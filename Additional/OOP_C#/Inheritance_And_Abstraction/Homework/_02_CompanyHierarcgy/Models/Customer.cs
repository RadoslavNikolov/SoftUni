namespace CompanyHierarcgy.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Customer : Person, ICustomer
    {
        private decimal purchaseAmmount;

        protected Customer(string id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public decimal PurchaseAmmount {
            get
            {
                return this.purchaseAmmount;
            }

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("purchasesAmmount", "Purchases ammount cannot be empty.");
                }

                this.purchaseAmmount = value;
            }
        }

        public void AddPurchasePrice(decimal purchasePrice)
        {
            this.PurchaseAmmount += purchasePrice;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Purchases ammount: {0}\n", this.PurchaseAmmount);

            return result.ToString();
        }

    }
}