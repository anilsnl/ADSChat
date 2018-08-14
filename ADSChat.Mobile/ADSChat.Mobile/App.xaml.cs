using System;
using ADSChat.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ADSChat.Mobile
{
	public partial class App : Application
	{
	    public static string Username;
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new LoginPage())
			{
                BackgroundColor = Color.Black,
                BarTextColor = Color.Red,
                Title = "ADS Chat"
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
