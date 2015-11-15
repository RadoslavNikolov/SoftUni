﻿namespace BidSystem.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Repositories;

    public class BidSystemData : IBidSystemData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;
        private IUserStore<User> userStore;

        public BidSystemData()
            : this(new BidSystemDbContext())
        {
        }

        public BidSystemData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Bid> Bids
        {
            get { return this.GetRepository<Bid>(); }
        }

        public IRepository<Offer> Offers
        {
            get { return this.GetRepository<Offer>(); }
        }

        public IUserStore<User> UserStore
        {
            get
            {
                if (this.UserStore == null)
                {
                    this.userStore = new UserStore<User>(this.dbContext);
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
                var type = typeof (GenericEfRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>) this.repositories[typeof (T)];
        }
    }
}