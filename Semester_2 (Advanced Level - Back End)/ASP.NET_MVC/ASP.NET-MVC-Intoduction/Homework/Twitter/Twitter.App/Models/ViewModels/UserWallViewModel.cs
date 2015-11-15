namespace Twitter.App.Models.ViewModels
{
    using System.Collections.Generic;

    public class UserWallViewModel
    {
        public UserFullViewModel User { get; set; }

        public IEnumerable<TweetViewModel> Tweets { get; set; }
    }
}