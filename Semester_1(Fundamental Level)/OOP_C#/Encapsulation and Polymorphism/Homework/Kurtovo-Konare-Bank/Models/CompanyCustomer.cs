namespace Kurtovo_Konare_Bank.Models
{
    using System;

    public class CompanyCustomer : Customer
    {
        private string eik;

        public CompanyCustomer(string firstName, string address, string eik) 
            : base(firstName, address)
        {
            this.Eik = eik;
        }

        public string Eik
        {
            get { return this.eik; }
            private set
            {
                if (value.Length != 9 && value.Length != 13)
                {
                    throw new ArgumentOutOfRangeException("value", "Eik must be 9 or 13 digit long");
                }

                int n;
                if (!int.TryParse(value, out n))
                {
                    throw new FormatException("EIK contains only digits");
                }

                this.eik = value;
            }
        }
    }
}