using System;
using Xamarin.Forms;

namespace KinoStatistics
{
	public class App : Application
	{
		public static int ScreenWidth;
		public static int ScreenHeight;
		public static float Xdpi;
		public static float Ydpi;

		public App ()
		{
			// The root page of your application
			// The root page of your application
			/*MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};*/

			var np = new NavigationPage (new BasicMenu ());
			MainPage = np;
		}
			
		protected override void OnStart ()
		{
			var networkConnection = DependencyService.Get<INetworkConnection> ();
			networkConnection.CheckNetworkConnection ();
			var networkStatus = networkConnection.IsConnected ? "Connected" : "Not Connected";

			if (networkStatus == "Not Connected") { 
				var np = new NavigationPage (new NoInternet ());
				MainPage = np;
			}
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

