namespace Twitter.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserFullViewModel : UserWallViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int TweetsCount { get; set; }

        public int FollowingCount { get; set; }

        public int FollowersCount { get; set; }

        public int FavoritesCount { get; set; }

        public IEnumerable<File> Files { get; set; }

        //        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public static Expression<Func<User, UserFullViewModel>> Create
        {
            get
            {
                return u => new UserFullViewModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    TweetsCount = u.OwnTweets.Count,
                    FollowingCount = u.Following.Count,
                    FollowersCount = u.Followers.Count,
                    FavoritesCount = u.FavouriteTweets.Count,
                    Email = u.Email,
                    Files = u.Files,
                    Phone = u.PhoneNumber ?? " "
                };
            }
        }
    }
}