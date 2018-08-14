using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ADSChat.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string username, string message)
        {
            Clients.Others.getMessage(username, message);
            Clients.Caller.getMe(message);
        }

        public override async Task OnConnected()
        {
      
            string info = Context.QueryString["username"] + " is joined with " + Context.ConnectionId + " connection ID";
            await Clients.All.getInfo(info);
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            
            string info = $"{Context.QueryString["username"]} left.";
             await Clients.All.getInfo(info);
        }
    }
}