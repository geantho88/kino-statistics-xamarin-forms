using System;
using System.Collections.Generic;
using Xamarin.Forms;
using KinoStatistics.BusinessLogic;
using System.Linq;
using KinoStatistics.Model;
using AdsPCL;

namespace KinoStatistics
{
	public partial class CountNumbers : ContentPage
	{
		int numberssort = 0;
		int countsort = 0;
		List<NumberStatistics> items = new List<NumberStatistics>();

		public CountNumbers ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var myBanner = new MyBanner();
			AdBanner.Children.Add (myBanner);
			items = AnalyzeEngine.NumbersStatisticsList.OrderByDescending(a => a.numbercount).ToList();
			CountList.ItemsSource = items;   
		}

		void sortnumberbtn_Tap (object sender, EventArgs e)
		{
			numberssort++;
			if (numberssort % 2 == 0)
			{
				sortnumberbtn.Source = ImageSource.FromFile("kssortup.png");
				CountList.ItemsSource = items.OrderByDescending(i => i.number).ToList();
			}
			else
			{
				sortnumberbtn.Source = ImageSource.FromFile("kssortdown.png");
				CountList.ItemsSource = items.OrderBy(i => i.number).ToList();
			}
		}

		void countbtn_Tap (object sender, EventArgs e)
		{
			countsort++;
			if (countsort % 2 == 0)
			{
				countbtn.Source =ImageSource.FromFile("kssortdown.png");
				CountList.ItemsSource = items.OrderByDescending(i => i.numberpercentage).ToList();
			}
			else
			{
				countbtn.Source =ImageSource.FromFile("kssortup.png");
				CountList.ItemsSource = items.OrderBy(i => i.numberpercentage).ToList();
			}
		}
	}
}

