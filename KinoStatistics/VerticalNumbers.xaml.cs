using System;
using System.Collections.Generic;

using Xamarin.Forms;
using KinoStatistics.Model;
using KinoStatistics.BusinessLogic;
using System.Linq;
using AdsPCL;

namespace KinoStatistics
{
	public partial class VerticalNumbers : ContentPage
	{
		Dictionary<int, string> PickerList;
		List<MultipleNumbers> nums = new List<MultipleNumbers> ();

		public VerticalNumbers ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var myBanner = new MyBanner ();
			AdBanner.Children.Add (myBanner);
			VerticalNumbersList.ItemsSource = nums;
			FillPickerList();
			CreateUiPicker ();
		}

		void ListItem_Click (object sender, ItemTappedEventArgs  e)
		{
			var item = e.Item as MultipleNumbers;
			DisplayActionSheet ("εμφανίστηκαν οι εξής λήγοντες ", "Ok", null, item.Numbers.ToArray ());
		}

		private void FillPickerList ()
		{
			PickerList = new Dictionary<int, string> () { 
				{ 0,"0" },
				{ 1,"1" },
				{ 2,"2" },
				{ 3,"3" },
				{ 4,"4" },
				{ 5,"5" },
				{ 6,"6" },
				{ 7,"7" },
				{ 8,"8" },
				{ 9,"9" },
			};
		}

		private void CreateUiPicker ()
		{

			Picker picker = new Picker {
				Title = "Λήγοντας αριθμός",
				HeightRequest = 50,
				BackgroundColor = Color.FromHex ("#255A9C"),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			picker.SelectedIndexChanged += OnPickerChanged;

			foreach (KeyValuePair<int, string> entry in PickerList) {
				picker.Items.Add (entry.Value);
			}

			PickerArea.Children.Add (picker);
		}

		void OnPickerChanged (object sender, EventArgs e)
		{
			var x = (Picker)sender;
			var SelectedNumber =x.Items[x.SelectedIndex];
			NoticeText.Text = "Εμφάνισεις δεκαδικών του λήγοντα αριθμού "+SelectedNumber ;
			NoticeText.HeightRequest = 15;
			nums = AnalyzeEngine.GetMultipleNumbers (SelectedNumber, 4).OrderByDescending (a => a.drawTime).ToList ();
			VerticalNumbersList.ItemsSource = nums;
		}
	}
}

