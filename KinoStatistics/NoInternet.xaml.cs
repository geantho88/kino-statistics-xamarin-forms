using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KinoStatistics
{
	public partial class NoInternet : ContentPage
	{
		double height = App.ScreenHeight;
		double width = App.ScreenWidth;

		public NoInternet ()
		{
			InitializeComponent ();
			Device.GetNamedSize (NamedSize.Small, typeof(Label));
			NavigationPage.SetHasNavigationBar(this, false);
			nointernettext.FontSize =  Device.GetNamedSize (NamedSize.Small, typeof(Label));
			nointernetlabel.FontSize =  Device.GetNamedSize (NamedSize.Medium, typeof(Label));

			if ((width < 480 && height <= 520)) {
				ksnowifi.HeightRequest= 130;
				WidthRequest = 100;
			}
		}

		async void ExitButton_Click (object sender, EventArgs e)
		{
			DependencyService.Get<IAppTerminate>().CloseApp();
		}
	}
}

