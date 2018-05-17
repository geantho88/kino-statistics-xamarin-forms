using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KinoStatistics
{
	public partial class TheGame : TabbedPage
	{
		public TheGame ()
		{

			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var height = App.ScreenHeight;
			var width = App.ScreenWidth;

			thegametext.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));
			fill1.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));
			fill2.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));
			Profit.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));
			theform.FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label));


			if ((width < 480 && height <= 520)) {
				thegametext.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				fill1.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				fill2.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				Profit.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				theform.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				thegametext.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
				ksdeltio.HeightRequest = 150;
				ksdeltio.WidthRequest = 120;
			
			}

			if ((width >= 600 && height >= 1024)) {
				thegametext.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				fill1.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				fill2.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				Profit.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
				theform.FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label));
			}

			if (width >= 1340 && height > 2260) {

				if (App.Xdpi < 570) {
					thegametext.FontSize = 23;
					fill1.FontSize = 23;
					fill2.FontSize = 23;
					Profit.FontSize = 23;
					theform.FontSize = 23;


					ksdeltio.WidthRequest = 250;
					ksdeltio.HeightRequest = 380;

					kshelp.WidthRequest = 350;
					kshelp.HeightRequest = 70;

					kshelp3.WidthRequest = 350;
					kshelp3.HeightRequest = 70;

					kstablekino.WidthRequest = 600;
					kstablekino.HeightRequest = 300;
				} 
				else {
					thegametext.FontSize = 18;
					fill1.FontSize = 18;
					fill2.FontSize = 18;
					Profit.FontSize = 18;
					theform.FontSize = 18;

			
					ksdeltio.WidthRequest = 180;
					ksdeltio.HeightRequest = 280;

					kshelp.WidthRequest = 350;
					kshelp.HeightRequest = 70;

					kshelp3.WidthRequest = 350;
					kshelp3.HeightRequest = 70;

					kstablekino.WidthRequest = 500;
					kstablekino.HeightRequest = 250;
				}
			}
				
		}
	}
}

