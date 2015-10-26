namespace Twitter.MVC.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("tweets")]
    public class TweetsHub : Hub
    {
        public void PostTweet(string username, string content)
        {
            this.Clients.Others.receiveTweet(username, content);
        }
    }
}