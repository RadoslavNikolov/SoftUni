﻿namespace BidSystem.RestServices.Providers
{
    using System.Threading;
    using Microsoft.AspNet.Identity;

    public class AspNetUserProvider : IUserProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }

        public bool IsAuthenticated
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.IsAuthenticated;
            }
        }
    }
}