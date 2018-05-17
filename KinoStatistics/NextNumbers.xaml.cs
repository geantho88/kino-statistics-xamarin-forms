using System;
using System.Collections.Generic;
using Xamarin.Forms;
using KinoStatistics.BusinessLogic;
using System.Collections.ObjectModel;
using KinoStatistics.Model;
using System.Linq;
using AdsPCL;

namespace KinoStatistics
{
	public partial class NextNumbers : ContentPage
	{
		int numberssort = 0;
		int countsort = 0;
		ObservableCollection<NumberStatistics> items = new ObservableCollection<NumberStatistics>();

		public NextNumbers ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var myBanner = new MyBanner();
			AdBanner.Children.Add (myBanner);
			items = AnalyzeEngine.NumbersStatisticsList;
			NextNumbersList.ItemsSource = items.OrderByDescending(a => a.countfromlastdraw); ;
		}

		private void sortnumberbtn_Tap(object sender, EventArgs e)
		{
			numberssort++;
			if (numberssort % 2 == 0)
			{
				sortnumberbtn.Source =  ImageSource.FromFile("kssortup.png");
				NextNumbersList.ItemsSource = items.OrderByDescending(i => i.number).ToList();
			}
			else
			{
				sortnumberbtn.Source =ImageSource.FromFile("kssortdown.png");
				NextNumbersList.ItemsSource = items.OrderBy(i => i.number).ToList();
			}
		}

		private void sortcountbtn_Tap(object sender, EventArgs e)
		{
			countsort++;
			if (countsort % 2 == 0)
			{
				sortcountbtn.Source = ImageSource.FromFile("kssortdown.png");
				NextNumbersList.ItemsSource = items.OrderByDescending(i => i.countfromlastdraw).ToList();
			}
			else
			{
				sortcountbtn.Source = ImageSource.FromFile("kssortup.png");
				NextNumbersList.ItemsSource = items.OrderBy(i => i.countfromlastdraw).ToList();
			}
		}
	}
}

