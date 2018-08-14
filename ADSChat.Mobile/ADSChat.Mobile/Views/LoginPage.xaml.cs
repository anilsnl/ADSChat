using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ADSChat.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

	    private async void BtnNext_OnClicked(object sender, EventArgs e)
	    {
	        if (string.IsNullOrEmpty(txtName.Text))
	            await DisplayAlert("Error", "Type a name to be able to start to the chat.", "ok");
	        else
	        {
	            App.Username = txtName.Text.ToUpper();
	            await Navigation.PushAsync(new ChatPage());
            }
        }
	}
}