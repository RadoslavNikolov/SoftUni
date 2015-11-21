namespace Laptop_Shop
{
    using System;

    public class Battery
    {
        private string batteryName;
        private double? batteryLife;

        public Battery()
            :this(null, null)
        {
        }

        public Battery(string batteryName)
            : this(batteryName, null)
        {
        }

        public Battery(string batteryName, double? batteryLife)
        {
            this.BatteryName = batteryName;
            this.BatteryLife = batteryLife;
        }


        public string BatteryName
        {
            get { return this.batteryName; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Battery name cannot be empty!");
                }

                this.batteryName = value;
            }
        }

        public double? BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life cannot be negative!");
                }

                this.batteryLife = value;
            }
        }

        public override string ToString()
        {
            string result = $"Battery: {this.BatteryName ?? "not provided"}\n";
            result += $"Battery life: {(this.BatteryLife != null ? this.BatteryLife + " hours" : "not provided")}";
            return result;
        }
    }
}