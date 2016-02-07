namespace AirConditionerTestingSystem.Models
{
    using System;
    using Helpers;

    public abstract class ModelAbstract
    {
        private string manufacturer;
        private string model;

        protected ModelAbstract(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                ////Bug: we do not check for value length
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Manufacturer", Constants.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Model", Constants.ModelMinLength));
                }

                this.model = value;
            }
        }
    }
}