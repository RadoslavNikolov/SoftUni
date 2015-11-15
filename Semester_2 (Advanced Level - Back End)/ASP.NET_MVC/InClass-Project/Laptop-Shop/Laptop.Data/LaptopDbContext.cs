namespace Laptop.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;

    public class LaptopDbContext : IdentityDbContext<User>
    {
        public LaptopDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static LaptopDbContext Create()
        {
            return new LaptopDbContext();
        }

        public virtual IDbSet<Laptop> Laptops { get; set; }
    }
}