namespace Portal.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.IdentityModels;
    using Repositories;

    public class ApplicationData : IApplicationData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;
        private IUserStore<ApplicationUser> userStore;

        public ApplicationData()
            : this(new ApplicationDbContext())
        {
        }

        public ApplicationData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }
    
        public IUserStore<ApplicationUser> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<ApplicationUser>(this.dbContext);
                }

                return this.userStore;
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}