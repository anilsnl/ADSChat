using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADSChat.Mobile.Models;
using ADSChat.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ADSChat.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
	    private ListPageModel model;
	    private HubClient Client;
		public ChatPage ()
		{
			InitializeComponent ();
            this.Title = $"Wellcome {App.Username}";
           
            model=new ListPageModel();
		    Client = new HubClient();
            Client.Connect(App.Username);
            Client.ConnectionErrorOcurned += Client_ConnectionErrorOcurned;
            Client.OnGetMessage += Client_OnGetMessage;
            Client.OnGetMyMessage += Client_OnGetMyMessage;
            Client.OnGetInfo += Client_OnGetInfo;
            this.BindingContext = model;
            
		}

        private void Client_OnGetInfo(string info)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                model.Chats.Add(new ChatModel("Info",info,ChatMessageType.Info));
            });
        }

        private void Client_OnGetMyMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                model.Chats.Add(new ChatModel("me",message,ChatMessageType.SentMessage));
            });
        }

        private void Client_OnGetMessage(string username, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                model.Chats.Add(new ChatModel(username,message,ChatMessageType.RecivedMessage));
            });
        }

        private async void Client_ConnectionErrorOcurned()
        {
            await DisplayAlert("Error", "En error has been appaied while connecting to the server...", "Ok");
        }

	    private void BtnSend_OnClicked(object sender, EventArgs e)
	    {
	        if (!string.IsNullOrEmpty(btnSend.Text.Trim(' ')))
	        {
	            Client.SendMessage(App.Username,txtMessage.Text);
	            txtMessage.Text = "";

	        }
	    }
	}
}