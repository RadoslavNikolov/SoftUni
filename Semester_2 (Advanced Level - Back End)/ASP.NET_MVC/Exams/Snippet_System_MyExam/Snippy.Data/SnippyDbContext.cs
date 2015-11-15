using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snippy.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class SnippyDbContext : IdentityDbContext<User>
    {
        public SnippyDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SnippyDbContext Create()
        {
            return new SnippyDbContext();
        }

        public virtual IDbSet<Snippet> Snippets { get; set; }

        public virtual IDbSet<Language> Languages { get; set; }

        public virtual IDbSet<Label> Labels { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Snippet>()
                .HasRequired(s => s.Author)
                .WithMany(s => s.Snippets)
                .WillCascadeOnDelete(false);
          
            base.OnModelCreating(modelBuilder);
        }
    }   
}
