using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using KinoStatistics.BusinessLogic;
using System.Threading.Tasks;
using Xamarin.Forms;
using KinoStatistics.Model;
using AdsPCL;

namespace KinoStatistics
{
	public partial class PercentageNumbers : ContentPage
	{
		int numberssort = 0;
		int percentagesort = 0;
		List<NumberStatistics> items = new List<NumberStatistics> ();

		public PercentageNumbers ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var myBanner = new MyBanner();
			AdBanner.Children.Add (myBanner);
			items = AnalyzeEngine.NumbersStatisticsList.OrderByDescending (a => a.numberpercentage).ToList ();
			PercentageList.ItemsSource = items;
		}

		private void sortnumberbtn_Tap (object sender, EventArgs e)
		{
			numberssort++;
			if (numberssort % 2 == 0) {
				sortnumberbtn.Source = ImageSource.FromFile ("kssortup.png");
				PercentageList.ItemsSource = items.OrderByDescending (i => i.number).ToList ();
			} else {
				sortnumberbtn.Source = ImageSource.FromFile ("kssortdown.png");
				PercentageList.ItemsSource = items.OrderBy (i => i.number).ToList ();
			}
		}

		private void percentagebtn_Tap (object sender, EventArgs e)
		{
			percentagesort++;
			if (percentagesort % 2 == 0) {
				percentagebtn.Source = ImageSource.FromFile ("kssortdown.png");
				PercentageList.ItemsSource = items.OrderByDescending (i => i.numberpercentage).ToList ();              
			} else {
				percentagebtn.Source = ImageSource.FromFile ("kssortup.png");
				PercentageList.ItemsSource = items.OrderBy (i => i.numberpercentage).ToList ();
			}
		}
	}
}

