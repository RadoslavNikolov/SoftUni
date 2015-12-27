namespace Orders.Models
{
    using System;

    public class Category
    {
        private int id;
        private string name;

        public Category(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }


        public int Id
        {
            get { return this.id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Id must be greater than 0");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Category name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public string Description { get; set; }
    }
}