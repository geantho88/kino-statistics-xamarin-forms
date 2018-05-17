using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using KinoStatistics.BusinessLogic;
using KinoStatistics.Model;
using System.Linq;

namespace KinoStatistics
{
	public partial class MyNumbers : ContentPage
	{
		string itemtoremove = null;
		Picker picker;

		double height = App.ScreenHeight;
		double width = App.ScreenWidth;

		public MyNumbers ()
		{
			
			InitializeComponent ();
			CreateUiPicker ();
			NavigationPage.SetHasNavigationBar (this, false);

			percentagenmbr.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			countnmbr.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			countbar.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			lastdrawdate1.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			lastdrawdate2.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			drawscount.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));
			posibility.FontSize = Device.GetNamedSize (NamedSize.Micro, typeof(Label));

			if ((width > 640 && width <= 720) && (height > 960 && height <= 1280)) {
				percentagenmbr.FontSize = 34;
				countnmbr.FontSize = 44;
				lastdrawdate1.FontSize = 44;
				lastdrawdate2.FontSize = 44;
				drawscount.FontSize = 44;
				posibility.FontSize = 44;

			}
				

			if (width >= 1340 && height > 2260) {
				if (App.Xdpi < 570) {
					title.FontSize = 35;
					detail1.FontSize = 20;
					entrytext.HeightRequest = 40;
					instertbutton.WidthRequest = 250;
					instertbutton.HeightRequest = 80;
					instertbutton.FontSize = 18;
					picker.HeightRequest = 60;
					percentagenmbr.FontSize = 25;
					countnmbr.FontSize = 25;
					lastdrawdate1.FontSize = 25;
					lastdrawdate2.FontSize = 25;
					drawscount.FontSize = 25;
					posibility.FontSize = 25;
				}

				else {
					title.FontSize = 25;
					detail1.FontSize = 15;
					entrytext.HeightRequest = 40;
					instertbutton.WidthRequest = 100;
					instertbutton.HeightRequest = 40;
					instertbutton.FontSize = 14;
					picker.HeightRequest = 40;
					percentagenmbr.FontSize = 20;
					countnmbr.FontSize = 20;
					lastdrawdate1.FontSize = 20;
					lastdrawdate2.FontSize = 20;
					drawscount.FontSize = 20;
					posibility.FontSize = 20;
				}
			} 
		

		
		}

		private void CreateUiPicker ()
		{
			string mynumbers = null;

			    picker = new Picker {
				Title = "Οι αριθμοί μου",
				HeightRequest = 50,
				BackgroundColor = Color.FromHex ("#255A9C"),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			try {
				mynumbers = DependencyService.Get<ISaveAndLoad> ().LoadText ("mynumbers.txt");
			} catch {
				DependencyService.Get<ISaveAndLoad> ().SaveText ("mynumbers.txt", "");
			}
			if (string.IsNullOrEmpty (mynumbers)) {

			} else {
				var savednumbers = mynumbers.Split (',').ToList ();
				foreach (var item in savednumbers) {
					if (!string.IsNullOrEmpty (item)) {
						picker.Items.Add (item); 
					}
				}
			}

			picker.SelectedIndexChanged += OnPickerChanged;
			PickerArea.Children.Add (picker);
		}

		void OnPickerChanged (object sender, EventArgs e)
		{
			var x = (Picker)sender;
			var selectednumber =x.Items[x.SelectedIndex];

			var favnumber = AnalyzeEngine.GetSingleNumberStatistics (selectednumber);
			percentagenmbr.Text = "Ποσοστό εμφάνισης " + favnumber.percentageshow.ToString () + " %";
			countnmbr.Text = "Εμφανίσεις " + favnumber.numbercount.ToString ();
			lastdrawdate1.Text = "Τελευταία εμφάνιση Στις ";
			lastdrawdate2.Text = favnumber.stringlastdrawshowedTime;
			drawscount.Text = "Έχει να εμφανιστεί " + favnumber.countfromlastdraw.ToString () + " κληρώσεις";
			posibility.Text = "Πιθανότητα εμφάνισης " + favnumber.possibilitytoshownext.ToString ();


			if (favnumber.possibilitytoshownext == PossibilityToShow.Υψηλή) {
				posibility.TextColor = Color.FromHex ("#FFFF0000");
			} else if (favnumber.possibilitytoshownext == PossibilityToShow.Μέτρια) {
				posibility.TextColor = Color.FromHex ("#FFF5A079");
			} else {
				posibility.TextColor = Color.FromHex ("#FF1ADA23");
			}
		}

		void Insert_Click (object sender, EventArgs  e)
		{
			try {
				if ((int.Parse (entrytext.Text) < 81) && (int.Parse (entrytext.Text) > 0)) {
					if (entrytext.Text.Length == 1) {
						entrytext.Text = "0" + entrytext.Text;
					}
					if (picker.Items.Contains (entrytext.Text)) {
						DisplayAlert ("Kino Statistics", "Ο αριθμός " + entrytext.Text + " υπάρχει ήδη στην λίστα των αγαπημένων αριθμών", "ΟΚ");
					} else {
						picker.Items.Add (entrytext.Text);
					}
				} else {
					DisplayAlert ("Kino Statistics", "Παρακαλώ εισάγετε αριθμό απο το 1 ως το 80", "ΟΚ");
				}
			} catch {
				DisplayAlert ("Kino Statistics", "Παρακαλώ εισάγετε αριθμό απο το 1 ως το 80", "ΟΚ");
			} finally {
				entrytext.Text = string.Empty;
			}
		}

		void ListItem_Click (object sender, ItemTappedEventArgs  e)
		{
			DeleteButtonArea.Children.Clear ();

			var item = e.Item as string;
			itemtoremove = item;
			var favnumber = AnalyzeEngine.GetSingleNumberStatistics (item);
			percentagenmbr.Text = "Ποσοστό εμφάνισης " + favnumber.percentageshow.ToString () + " %";
			countnmbr.Text = "Εμφανίσεις " + favnumber.numbercount.ToString ();
			lastdrawdate1.Text = "Τελευταία εμφάνιση Στις ";
			lastdrawdate2.Text = favnumber.stringlastdrawshowedTime;
			drawscount.Text = "Έχει να εμφανιστεί " + favnumber.countfromlastdraw.ToString () + " κληρώσεις";
			posibility.Text = "Πιθανότητα εμφάνισης " + favnumber.possibilitytoshownext.ToString ();


			if (favnumber.possibilitytoshownext == PossibilityToShow.Υψηλή) {
				posibility.TextColor = Color.FromHex ("#FFFF0000");
			} else if (favnumber.possibilitytoshownext == PossibilityToShow.Μέτρια) {
				posibility.TextColor = Color.FromHex ("#FFF5A079");
			} else {
				posibility.TextColor = Color.FromHex ("#FF1ADA23");
			}

			Button numberbtn = new Button ();
			numberbtn.Text = "Αφαίρεση αριθμού";
			numberbtn.WidthRequest = 200;
			numberbtn.HeightRequest = 68;
			numberbtn.BorderRadius = 5;
			numberbtn.FontSize = 14;
			numberbtn.BackgroundColor = Color.FromHex ("#255A9C");
		
			DeleteButtonArea.Children.Add (numberbtn);
		}


		protected override bool OnBackButtonPressed ()
		{
			base.OnBackButtonPressed ();
			DependencyService.Get<ISaveAndLoad> ().ClearText ("mynumbers.txt");
			string numbersSave = null;
			foreach (string item in this.picker.Items) {
				numbersSave += "," + item;
			}
			DependencyService.Get<ISaveAndLoad> ().SaveText ("mynumbers.txt", numbersSave);
			return false;
		}
	}
}

