namespace Twitter.App.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("tweetshub")]
    public class TweetsHub: Hub
    {

  
        public void SendTweets(string tweet)
        {
            this.Clients.All.receiveTweet(tweet);
        }


         
    }
}