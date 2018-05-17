using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using KinoStatistics.BusinessLogic;
using KinoStatistics.Model;
using AdsPCL;

namespace KinoStatistics
{
	public partial class RandomNumbers : ContentPage
	{
		double height = App.ScreenHeight;
		double width = App.ScreenWidth;

		CheckBox allchk;
		CheckBox normalchk;
		CheckBox highchk;

		string SelectedGameNumber;
		string SelectedPropability;

		List<Button> btnsList = new List<Button> ();

		public RandomNumbers ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			var myBanner = new MyBanner();
			AdBanner.Children.Add (myBanner);
			normalchk = new CheckBox () {
				DefaultText = "Όλες",
				FontSize = 12,
                TextColor = Color.Black
            };

			allchk = new CheckBox () {
				DefaultText = "Μέτρια & Υψηλή",
				Checked = true,
				FontSize = 12,
                TextColor = Color.Black
            };
					
			highchk = new CheckBox () {
				DefaultText = "Υψηλή",
				FontSize = 12,
                TextColor = Color.Black
            };
					
			SelectedPropability = "Όλες";

			allchk.CheckedChanged += Onallchk;
			normalchk.CheckedChanged += Onnormalchk;
			highchk.CheckedChanged += Onhighchk;

			CheckBoxArea.Children.Add (allchk);
			CheckBoxArea.Children.Add (normalchk);
			CheckBoxArea.Children.Add (highchk);

			for (int i = 1; i < 13; i++) {
				Button numberbtn = new Button ();
				numberbtn.Text = i.ToString ();

				numberbtn.WidthRequest = 38;
				numberbtn.HeightRequest = 38;
				numberbtn.BorderRadius = 5;
				numberbtn.FontSize = 1;
				numberbtn.TextColor = Color.Black;

				if ((width > 0 && width <= 640) && (height > 0 && height <= 960)) {
					numberbtn.WidthRequest = 38;
					numberbtn.HeightRequest = 32;
					numberbtn.BorderRadius = 5;
					numberbtn.FontSize = 9;
				}

				if ((width > 640 && width <= 720) && (height > 960 && height <= 1280)) {
					numberbtn.WidthRequest = 44;
					numberbtn.HeightRequest = 44;
					numberbtn.BorderRadius = 5;
					numberbtn.FontSize = 12;
				}

				if ((width > 1000) && (height > 1900)) {
					numberbtn.WidthRequest = 48;
					numberbtn.HeightRequest = 48;
					numberbtn.BorderRadius = 5;
					numberbtn.FontSize = 12;
				}

				if (width >= 1340 && height > 2260) {
					if (App.Xdpi < 570) {
						title.FontSize = 35;
						detail1.FontSize = 18;
						detail2.FontSize = 18;
						numberbtn.WidthRequest = 48;
						numberbtn.HeightRequest = 48;
						numberbtn.BorderRadius = 5;
						numberbtn.FontSize = 15;
						GenerateButton.WidthRequest = 200;
						GenerateButton.FontSize = 14;
					    GenerateButton.TextColor = Color.Black;

						allchk.WidthRequest = 150;
						allchk.HeightRequest = 150;
						allchk.FontSize = 20;

						normalchk.WidthRequest = 150;
						normalchk.HeightRequest = 150;
						normalchk.FontSize = 20;

						highchk.WidthRequest = 150;
						highchk.HeightRequest = 150;
						highchk.FontSize = 20;
					} 
					else {
						title.FontSize = 25;
						detail1.FontSize = 14;
						detail2.FontSize = 14;
						numberbtn.WidthRequest = 38;
						numberbtn.HeightRequest = 38;
						numberbtn.BorderRadius = 5;
						numberbtn.FontSize = 12;
						GenerateButton.WidthRequest = 150;
						GenerateButton.FontSize = 12;
                        GenerateButton.TextColor = Color.Black;
                        allchk.WidthRequest = 80;
						allchk.HeightRequest = 100;
						allchk.FontSize = 13;
		

						normalchk.WidthRequest = 100;
						normalchk.HeightRequest = 100;
						normalchk.FontSize = 13;

						highchk.WidthRequest = 80;
						highchk.HeightRequest = 100;
						highchk.FontSize = 13;
					}
				}

					
				numberbtn.BackgroundColor = Color.FromHex ("#FF818181");
				numberbtn.Clicked += OnButtonClicked;

				if (i < 7) {
					ButtonsArea1.Children.Add (numberbtn);
				} else {
					ButtonsArea2.Children.Add (numberbtn);
				}

				btnsList.Add (numberbtn);
			}
		}


		void Onallchk (object sender, EventArgs e)
		{
			var x = (CheckBox)sender;
			SelectedPropability = x.Text;

			normalchk.Checked = false;
			highchk.Checked = false;
		}


		void Onnormalchk (object sender, EventArgs e)
		{
			var x = (CheckBox)sender;
			SelectedPropability = x.Text;

			allchk.Checked = false;
			highchk.Checked = false;
		}


		void Onhighchk (object sender, EventArgs e)
		{
			var x = (CheckBox)sender;
			SelectedPropability = x.Text;

			normalchk.Checked = false;
			allchk.Checked = false;
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			foreach (var btn in btnsList) {
				btn.BackgroundColor = Color.FromHex ("#FF818181");
			}

			Button button = (Button)sender;
			button.BackgroundColor = Color.FromHex ("#00B200");

			SelectedGameNumber = button.Text;
		}


		void GenerateButtonClick (object sender, EventArgs e)
		{
			int i = 0;
			if ((!String.IsNullOrEmpty (SelectedGameNumber)) && (!string.IsNullOrEmpty (SelectedPropability))) {
				var Generatednumbers = NumbersGenerate (int.Parse (SelectedGameNumber), SelectedPropability);

				GenerationArea1.Children.Clear ();
				GenerationArea2.Children.Clear ();

				foreach (var item in Generatednumbers) {
					i++;
					Button numberbtn = new Button ();
					numberbtn.Text = item.ToString ();

					numberbtn.WidthRequest = 38;
					numberbtn.HeightRequest = 38;
					numberbtn.BorderRadius = 5;
					numberbtn.FontSize = 1;
					numberbtn.TextColor = Color.Black;

					if ((width > 0 && width <= 640) && (height > 0 && height <= 960)) {
						numberbtn.WidthRequest = 38;
						numberbtn.HeightRequest = 32;
						numberbtn.BorderRadius = 5;
						numberbtn.FontSize = 9;
					}

					if ((width > 640 && width <= 720) && (height > 960 && height <= 1280)) {
						numberbtn.WidthRequest = 44;
						numberbtn.HeightRequest = 44;
						numberbtn.BorderRadius = 5;
						numberbtn.FontSize = 12;
					}

					if ((width > 1000) && (height > 1900)) {
						numberbtn.WidthRequest = 48;
						numberbtn.HeightRequest = 48;
						numberbtn.BorderRadius = 5;
						numberbtn.FontSize = 12;
					}

					if (width >= 1340 && height > 2260) {

						if (App.Xdpi <= 570) {
							numberbtn.WidthRequest = 48;
							numberbtn.HeightRequest = 48;
							numberbtn.BorderRadius = 5;
							numberbtn.FontSize = 18;
						} 
						else {
							numberbtn.WidthRequest = 48;
							numberbtn.HeightRequest = 48;
							numberbtn.BorderRadius = 5;
							numberbtn.FontSize = 14;
						}
					}

					numberbtn.BackgroundColor = Color.FromHex ("#DADA46");
					numberbtn.Clicked += OnGeneratedButtonClicked;

					if (i < 7) {
						GenerationArea1.Children.Add (numberbtn);
					} else {
						GenerationArea2.Children.Add (numberbtn);
					}
				}

			} else {
				DisplayAlert ("Kino Statistics", "Παρακαλώ επιλέξτε τις πιθανότητές εμφάνισης αριθμών και τύπο παιχνιδιού ", "ΟΚ");
			}
		}

		public List<int> NumbersGenerate (int SelectedGamenumber, string SelectedPropability)
		{
			Random rnd = new Random ();

			if (SelectedPropability == "Όλες") {
				List<int> numbersGenerated = new List<int> ();
				var numbers = AnalyzeEngine.NumbersStatisticsList.Where (a => (a.possibilitytoshownext == PossibilityToShow.Υψηλή || a.possibilitytoshownext == PossibilityToShow.Μέτρια)).ToArray ();

				if (numbers.Count () < SelectedGamenumber) {
					DisplayAlert ("Kino Statistics", "Το σύνολο των αριθμών με υψηλό και μέτριο ποσοστό εμφάνισης είναι " + numbers.Count () + " , μπορείτε να επιλέξετε παιχνίδι ώς " + numbers.Count () + " αριθμών", "OK");
					return null;
				}

				while (numbersGenerated.Count < SelectedGamenumber) {
					int nmbr = numbers [rnd.Next (numbers.Length)].number;
					if (!numbersGenerated.Contains (nmbr)) {
						numbersGenerated.Add (nmbr);
					}
				}

				return numbersGenerated;
			} else if (SelectedPropability == "Υψηλή") {
				List<int> numbersGenerated = new List<int> ();
				var numbers = AnalyzeEngine.NumbersStatisticsList.Where (a => a.possibilitytoshownext == PossibilityToShow.Υψηλή).ToArray ();
				try {
					if (numbers.Count () < SelectedGamenumber) {
						DisplayAlert ("Kino Statistics", "Το σύνολο των αριθμών με υψηλό ποσοστό εμφάνισης είναι " + numbers.Count () + " , μπορείτε να επιλέξετε παιχνίδι ώς " + numbers.Count () + " αριθμών", "OK");
						return null;
					}
					while (numbersGenerated.Count < SelectedGamenumber) {
						int nmbr = numbers [rnd.Next (numbers.Length)].number;
						if (!numbersGenerated.Contains (nmbr)) {
							numbersGenerated.Add (nmbr);
						}
					}

					return numbersGenerated;
				} catch {
					return null;
				}
			} else {
				List<int> numbersGenerated = new List<int> ();
				for (int i = 0; i < SelectedGamenumber; i++) {
					int nmbr = rnd.Next (1, 80);
					numbersGenerated.Add (nmbr);
				}

				return numbersGenerated;
			}
		}

		void OnGeneratedButtonClicked (object sender, EventArgs e)
		{
			Button button = (Button)sender;
			var statistics = AnalyzeEngine.GetSingleNumberStatistics(button.Text.ToString());
			DisplayActionSheet ("Αριθμός "+button.Text, "Ok", null ,"Σύνολο εμφανίσεων " + statistics.numbercount , "Ποσοστό εμφάνισης " + statistics.percentageshow.ToString() +"%", "Πιθανότητα εμφάνισης " + statistics.possibilitytoshownext.ToString(), "Τελευταία εμφάνιση πριν από " + statistics.countfromlastdraw.ToString() + " Κληρώσεις ","στις " + statistics.stringlastdrawshowedTime.ToString());
			//DisplayAlert ("Αριθμός "+button.Text, "Σύνολο εμφανίσεων " + statistics.numbercount + " " + "Ποσοστό εμφάνισης " + statistics.percentageshow.ToString() + " % " + "Πιθανότητα εμφάνισης " + statistics.possibilitytoshownext.ToString() + " Τελευταία εμφάνιση πριν από " + statistics.countfromlastdraw.ToString() + " Κληρώσεις στις " + statistics.stringlastdrawshowedTime.ToString(),"OK");
		}

	}
}

