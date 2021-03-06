namespace BookShopSystem.Data
{
    using System.Data.Entity;
    using BookShop_Web_API.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class BookShopContext : IdentityDbContext<ApplicationUser>
    {
        public BookShopContext()
            : base("BookShop")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Author> Authors { get; set; }
        public virtual IDbSet<Purchase> Purchases { get; set; }
        public virtual IDbSet<UserSession> UserSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedId");
                    m.ToTable("RelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }
    }
}