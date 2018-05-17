using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KinoStatistics
{
	public partial class Help : ContentPage
	{
		public Help ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			var height = App.ScreenHeight;
			var width = App.ScreenWidth;

			helptext1.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));
			helptext2.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));

			if ((width < 480 && height <= 520)) {
				helptext1.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				helptext2.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			}

			if ((width >= 600 && height >= 1024)) {
				helptext1.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				helptext2.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
			}

			if (width >= 1340 && height > 2260) {

				if (App.Xdpi < 570) {
					Title.FontSize = 35;

					helptext1.FontSize = 23;
					helptext2.FontSize = 23;

					AVC.WidthRequest = 186;
					AVC.HeightRequest = 186;
				} else {
					Title.FontSize = 35;

					helptext1.FontSize = 18;
					helptext2.FontSize = 18;

					AVC.WidthRequest = 126;
					AVC.HeightRequest = 126;
				}
			}
		}

		void likeBtn_Click (object sender, EventArgs e)
		{

		}

		void mailBtn_Click (object sender, EventArgs e)
		{

		}
	}
}

