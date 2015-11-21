namespace Laptop_Shop
{
    using System;
    using System.Text;

    public class Laptop
    {
        private string model;
        private string manifacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private decimal price;

        public Laptop(string model, decimal price, string manifacturer = null, string processor = null, string ram = null, string graphicsCard = null, string hdd = null, string screen = null, string batteryName = null, double? batteryLife = null)
        {
            this.Model = model;
            this.Price = price;
            this.Manifacturer = manifacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = new Battery(batteryName, batteryLife);
        }

        public Battery Battery { get; set; }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Laptop model cannot be null or empty!");
                }

                this.model = value;
            }
        }

        public string Manifacturer
        {
            get { return this.manifacturer; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manifacturer cannot be empty!");
                }

                this.manifacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Processor description cannot be empty!");
                }

                this.processor = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("RAM description cannot be empty!");
                }

                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Graphics card description cannot be empty!");
                }

                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("HDD description cannot be empty!");
                }

                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Screen description cannot be empty!");
                }

                this.screen = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }

                this.price = value;
            }
        }


        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Manifacturer: {this.Manifacturer ?? "not provided"}");
            result.AppendLine($"Processor: {this.Processor ?? "not provided"}");
            result.AppendLine($"RAM: {this.Ram ?? "not provided"}");
            result.AppendLine($"Graphics card: {this.GraphicsCard ?? "not provided"}");
            result.AppendLine($"HDD: {this.Hdd ?? "not provided"}");
            result.AppendLine($"Screem: {this.Screen ?? "not provided"}");
            result.AppendLine(this.Battery.ToString());
            result.AppendLine($"Price: {this.Price:N2} lv.");

            return result.ToString();
        }
    }
}