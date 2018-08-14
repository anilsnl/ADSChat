using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Serialization;

namespace ADSChat.Mobile.Services
{
    public class HubClient
    {
        private const string BASE_URL = "http://adschat.azurewebsites.net/";
        private HubConnection Connection;
        private IHubProxy Proxy;

        public delegate void Errır();

        public delegate void GetMessage(string username, string message);

        public delegate void GetMe(string message);

        public delegate void GetInfo(string info);


        public event Errır ConnectionErrorOcurned;
        public event GetMessage OnGetMessage ;
        public event GetMe OnGetMyMessage;
        public event GetInfo OnGetInfo;


        public void Connect(string _username)
        {
            Connection=new HubConnection(BASE_URL,new Dictionary<string, string>
            {
                { "username", _username }
            });

            Proxy = Connection.CreateHubProxy("ChatHub");

            Proxy.On<string, string>("GetMessage",(username, message )=>
            {
                OnGetMessage?.Invoke(username,message);
            });

            Proxy.On<string>("GetMe", (message) =>
            {
                OnGetMyMessage?.Invoke(message);
            });


            Proxy.On<string>("GetInfo", (info) =>
            {
                OnGetInfo?.Invoke(info);
            });

            Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                   ConnectionErrorOcurned?.Invoke();
                }
            });
        }


        public void SendMessage(string username, string message)
        {
            Proxy.Invoke("SendMessage", username, message);
        }

        public  Task Start()
        {
            return  Connection.Start();
        }
    }
}
