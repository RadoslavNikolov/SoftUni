namespace AirConditionerTestingSystem.Models
{
    using System;
    using System.Text;
    using Helpers;

    public class AirConditioner : ModelAbstract
    {
        private int volumeCovered;
        private int electricityUsed;
        private int powerUsage;

        ////Bug: missing constructor overload for car conditioner
        public AirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
            this.Type = "car";
        }

        public AirConditioner(string manufacturer, string model, string ennergyEfficiencyRating, int powerUsage)
            : base(manufacturer, model)
        {
            switch (ennergyEfficiencyRating)
            {
                case "A":
                    this.EnergyRating = 10;
                    break;
                case "B":
                    this.EnergyRating = 12;
                    break;
                case "C":
                    this.EnergyRating = 15;
                    break;
                case "D":
                    this.EnergyRating = 20;
                    break;
                case "E":
                    this.EnergyRating = 90;
                    break;
                ////Bug: missin validation
                default:
                    throw new ArgumentException(Constants.INCORRECTRATING);
            }

            this.PowerUsage = powerUsage;
            this.Type = "stationary";
        }

        public AirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
            this.Type = "plane";
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            protected internal set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NONPOSITIVE, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public string Type { get; private set; }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NONPOSITIVE, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public int EnergyRating { get; private set; }

        public int Test()
        {
            if (this.Type == "stationary")
            {
                var remainder = this.powerUsage - 1000;
                var calculatedRating = 0;

                if (remainder < 0)
                {
                    calculatedRating = 10;
                }

                if (0 <= remainder && remainder <= 250)
                {
                    calculatedRating = 12;
                }

                if (250 < remainder && remainder <= 500)
                {
                    calculatedRating = 15;
                }

                if (500 < remainder && remainder <= 1000)
                {
                    calculatedRating = 20;
                }

                if ( remainder > 1000)
                {
                    calculatedRating = 90;
                }

                if (calculatedRating <= this.EnergyRating)
                {
                    return 1;
                }
            }
            else if (this.Type == "car")
            {
                double sqrtVolume = Math.Sqrt(this.VolumeCovered);
                ////Bug: ">=" instead of "<"
                if (sqrtVolume >= 3)
                {
                    return 1;
                }

                ////Bug: not necessary
                ////return 2;
            }
            else if (this.Type == "plane")
            {
                double sqrtVolume = Math.Sqrt(this.VolumeCovered);

                if (this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity)
                {
                    return 1;
                }
            }

            return 0;
        }

        public override string ToString()
        {
            var print = new StringBuilder();
            print.AppendLine("Air Conditioner");
            print.AppendLine("====================");
            print.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            print.AppendLine(string.Format("Model: {0}", this.Model));

            if (this.Type == "stationary")
            {
                string energy = "A";
                switch (this.EnergyRating)
                {
                    case 12:
                        energy = "B";
                        break;
                    case 15:
                        energy = "C";
                        break;
                    case 20:
                        energy = "D";
                        break;
                    case 90:
                        energy = "E";
                        break;
                }

                print.AppendLine(string.Format("Required energy efficiency rating: {0}", energy));
                print.AppendLine(string.Format("Power Usage(KW / h): {0}", this.PowerUsage));
            }
            else if (this.Type == "car")
            {
                print.AppendLine(string.Format("Volume Covered: {0}", this.VolumeCovered));
            }
            else
            {
                print.AppendLine(string.Format("Volume Covered: {0}", this.VolumeCovered));
                print.AppendLine(string.Format("Electricity Used: {0}", this.ElectricityUsed));
            }

            print.Append("====================");

            return print.ToString();
        }
    }
}
