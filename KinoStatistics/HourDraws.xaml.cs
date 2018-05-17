using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using KinoStatistics.Model;
using KinoStatistics.BusinessLogic;
using AdsPCL;

namespace KinoStatistics
{
	public partial class HourDraws : ContentPage
	{
		Dictionary<int, string> Hours;
		List<HourlyNumberStatistics> StatisticsList = new List<HourlyNumberStatistics> ();

		public HourDraws ()
		{			
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var myBanner = new MyBanner();
			AdBanner.Children.Add (myBanner);
			ResetHoursList ();
			CreateUiPicker ();

			if (AnalyzeEngine.DrawsPerHour == null || AnalyzeEngine.DrawsPerHour.Count() <= 0)
			{
				AnalyzeEngine.GetDrawsByHour();
			}
			if (StatisticsList.Count == 0)
			{
				StatisticsList = AnalyzeEngine.AnalyzeNumbersbyhour(9);
			    HoursDrawList.ItemsSource = StatisticsList;
				ResetHoursList();
			}
		}

		private void ResetHoursList ()
		{
			Hours = new Dictionary<int, string> () { 
				{ 9, "09:00 π.μ - 10:00 π.μ" },
				{ 10,"10:00 π.μ - 11:00 π.μ" },
				{ 11,"11:00 π.μ - 12:00 π.μ" },
				{ 12,"12:00 π.μ - 01:00 μ.μ" },
				{ 13,"01:00 μ.μ - 02:00 μ.μ" },
				{ 14,"02:00 μ.μ - 03:00 μ.μ" },
				{ 15,"03:00 μ.μ - 04:00 μ.μ" },
				{ 16,"04:00 μ.μ - 05:00 μ.μ" },
				{ 17,"05:00 μ.μ - 06:00 μ.μ" },
				{ 18,"06:00 μ.μ - 07:00 μ.μ" },
				{ 19,"07:00 μ.μ - 08:00 μ.μ" },
				{ 20,"08:00 μ.μ - 09:00 μ.μ" },
				{ 21,"09:00 μ.μ - 10:00 μ.μ" },
			};

			// HoursList.ItemsSource = Hours.Values;
		}

		private void CreateUiPicker ()
		{

			Picker picker = new Picker {
				Title = "Επιλέξτε την ώρα απο εδώ",
				HeightRequest = 50,
				BackgroundColor = Color.FromHex ("#255A9C"),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			picker.SelectedIndexChanged += OnPickerChanged;

			foreach (KeyValuePair<int, string> entry in Hours) {
				picker.Items.Add (entry.Value);
			}
				
			PickerArea.Children.Add (picker);

			NoticeText.Text ="Εμφάνιση στατιστικών για τις κληρώσεις μεταξύ των ωρών  09:00 π.μ - 10:00 π.μ";
		}

		void OnPickerChanged (object sender, EventArgs e)
		{
			var x = (Picker)sender;
			var selectedHours =x.Items[x.SelectedIndex];
			NoticeText.Text = "Εμφάνιση στατιστικών για τις κληρώσεις μεταξύ των ωρών "+ selectedHours ;
			StatisticsList.Clear();
			var index = Hours.FirstOrDefault(z => z.Value == x.Items[x.SelectedIndex]).Key;
			StatisticsList = AnalyzeEngine.AnalyzeNumbersbyhour(index);
			HoursDrawList.ItemsSource = StatisticsList;
		}

		void ListItem_Click (object sender, ItemTappedEventArgs  e)
		{
			var item = e.Item as HourlyNumberStatistics;
			var number = (int)item.number;


			string[]  numberhoursshow = this.StatisticsList.Where(a => a.number == number).Select(a => a.stringHours).SingleOrDefault().ToArray();
			//string s = String.Join(",", numberhoursshow);
			DisplayActionSheet ("Ο αριθμός "+item.number+" εμφανίστηκε στις", "Ok", null,numberhoursshow);

		}
	}
}

