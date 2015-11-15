using System;

namespace _02_Laptop_Shop
{
    class Laptop
    {
        private string _model;
        private string _manifacturer;
        private string _processor;
        private string _ram;
        private string _graphicsCard;
        private int? _hdd;
        private string _screen;
        private Battery _battery;
        private decimal _price;

        public string Model
        {
            get { return this._model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be empty.");
                }
                this._model = value;
            }
        }

        public string Manifacturer
        {
            get { return this._manifacturer; }
            set
            {
                if (value != null && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manifacturer cannot be empty.");
                }
                this._manifacturer = value;
            }
        }

        public string Processor
        {
            get { return this._processor; }
            set
            {
                if (value != null && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Processor cannot be empty.");
                }
                this._processor = value;
            }
        }

        public string Ram
        {
            get { return this._ram; }
            set
            {
                if (value != null && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ram cannot be empty.");
                }
                this._ram = value;
            }
        }

        public string GraphicsCard
        {
            get { return this._graphicsCard; }
            set
            {
                if (value != null && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Graphic card cannot be empty.");
                }
                this._graphicsCard = value;
            }
        }

        public int? Hdd
        {
            get { return this._hdd; }
            set
            {
                if (value <= 0 )
                {
                    throw new ArgumentOutOfRangeException("Invalid size of the HDD.");
                }
                this._hdd = value;
            }
        }

        public string Screen
        {
            get { return this._screen; }
            set {
                if (value != null && string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Screen cannot be empty.");
                }
                this._screen = value;
            }
        }

        public decimal Price
        {
            get { return this._price; }
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                this._price = value;
            }
        }

        public Laptop(string model, decimal price, string manifacturer = null, string processor = null, string ram = null, string graphicsCard = null, int? hdd = null, string screen = null, string batteryType = null, double? batteryLife = null)
        {
            this.Model = model;
            this.Price = price;
            this.Manifacturer = manifacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this._battery = new Battery(batteryType,batteryLife);
        }

        public override string ToString()
        {
            string printResult = String.Format("Model: {0}\n",this.Model);
            printResult += String.Format("Manifacturer: {0}\n",this.Manifacturer ?? "not provided");
            printResult += String.Format("Processor: {0}\n",this.Processor ?? "not provided");
            printResult += String.Format("RAM: {0}\n",this.Ram ?? "not provided");
            printResult += String.Format("Graphic card: {0}\n",this.GraphicsCard ?? "not provided");
            printResult += String.Format("HDD: {0}\n",this.Hdd != null ? this.Hdd + " GB" : "not provided");
            printResult += String.Format("Screen : {0}\n",this.Screen ?? "not provided");
            printResult += String.Format("{0}\n",this._battery);
            printResult += String.Format("Price: {0:N2} lv.\n",this.Price);
            return printResult;
        }
    }
}
