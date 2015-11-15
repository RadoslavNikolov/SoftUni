using System;

namespace _02_Laptop_Shop
{
    class Battery
    {
        private string _batteryType;
        private double? _batteryLife;

        public string BatteryType
        {
            get { return this._batteryType; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Battery type cannot be empty");
                }
                this._batteryType = value;
            }
        }

        public double? BatteryLife
        {
            get { return this._batteryLife; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life cannot be negative.");
                }
                this._batteryLife = value;
            }
        }

        public Battery(string batteryType = null, double? batteryLife = null)
        {
            this.BatteryType = batteryType;
            this.BatteryLife = batteryLife;
        }

        public override string ToString()
        {
            string result = $"Battery: {this.BatteryType ?? "not provided"}\n";
            result += $"Battery life: {(this.BatteryLife != null ? this.BatteryLife + " hours" : "not provided")}";
            return result;
        }
    }
}
