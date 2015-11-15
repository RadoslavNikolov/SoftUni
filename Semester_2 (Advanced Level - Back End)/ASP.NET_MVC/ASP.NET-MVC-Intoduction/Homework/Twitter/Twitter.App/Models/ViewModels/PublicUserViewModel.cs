namespace Twitter.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class PublicUserViewModel
    {
        public static Expression<Func<User, PublicUserViewModel>> fromUsers
        {
            get
            {
                return u => new PublicUserViewModel()
                {
                    Username = u.UserName,
                    Tweets = u.OwnTweets.AsQueryable().Select(TweetViewModel.Create).ToList(),
                    //Favourites = u.FavouriteTweets.AsQueryable().Select(TweetViewModel.Create).ToList(),
                    Followers = u.Followers.Select(f => f.UserName).ToList(),
                    Following = u.Following.Select(f => f.UserName).ToList()
                };
            }
        }

        public string Username { get; set; }

        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public IEnumerable<TweetViewModel> Favourites { get; set; }

        public IEnumerable<string> Followers { get; set; }

        public IEnumerable<string> Following { get; set; }


        public static PublicUserViewModel Create(User user)
        {
            return new PublicUserViewModel
            {
                Username = user.UserName,
                Tweets = user.OwnTweets.AsQueryable().Select(TweetViewModel.Create).ToList(),
                //Favourites = u.FavouriteTweets.AsQueryable().Select(TweetViewModel.Create).ToList(),
                Followers = user.Followers.Select(f => f.UserName).ToList(),
                Following = user.Following.Select(f => f.UserName).ToList()
            };
        }
    }
}