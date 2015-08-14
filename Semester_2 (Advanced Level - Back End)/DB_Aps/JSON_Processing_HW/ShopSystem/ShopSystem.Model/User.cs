namespace ShopSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<Product> SoldProduct { get; set; }

        public ICollection<Product> BoughtProduct { get; set; }
    }
}