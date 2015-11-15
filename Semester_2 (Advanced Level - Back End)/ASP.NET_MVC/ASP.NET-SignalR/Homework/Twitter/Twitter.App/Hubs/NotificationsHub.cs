

namespace Twitter.App.Hubs
{
    using System.Configuration;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Models.ViewModels;
    using Twitter.Models;

    [HubName("notifications")]
    public class NotificationsHub : Hub
    {

        public void SendNotification(string type, string notification)
        {
            this.Clients.All.receiveNotification(type, notification);
        }


        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.Caller.joinRoom(room);
        }

        public void SendToRoom(string type, string[] room, string notification)
        {
            var msg = string.Format("{0}: {1}", this.Context.ConnectionId, notification);

            for (int i = 0; i < room.Length; i++)
            {
                Clients.Group(room[i]).receiveNotification(type, notification);

            }
        }
    }
}