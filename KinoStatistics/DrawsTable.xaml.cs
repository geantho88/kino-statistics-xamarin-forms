using System;
using System.Collections.Generic;
using Xamarin.Forms;
using KinoStatistics.BusinessLogic;
using System.Collections.ObjectModel;
using KinoStatistics.Model;
using AdsPCL;


namespace KinoStatistics
{
	public partial class DrawsTable : ContentPage
	{
		double height = App.ScreenHeight;
		double width = App.ScreenWidth;

		ObservableCollection<NumberStatistics> items = new ObservableCollection<NumberStatistics> ();
		int count = 0;

		public DrawsTable ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			var myBanner = new MyBanner ();
			AdBanner.Children.Add (myBanner);
			FillNumberPanel ();
		}

		private void FillNumberPanel ()
		{
            items = AnalyzeEngine.NumbersStatisticsList;

            foreach (var number in items)
            {
                count++;

                Button selectedButton = this.FindByName<Button>("Button" + count);
                selectedButton.Clicked += OnGeneratedButtonClicked;

                if (number.possibilitytoshownext == PossibilityToShow.Χαμηλή)
                {
                    selectedButton.BackgroundColor = Color.FromHex("#FF1ADA23");
                }
                if (number.possibilitytoshownext == PossibilityToShow.Μέτρια)
                {
                    selectedButton.BackgroundColor = Color.FromHex("#FFF5A079");
                }
                if (number.possibilitytoshownext == PossibilityToShow.Υψηλή)
                {
                    selectedButton.BackgroundColor = Color.FromHex("#FFFF0000");
                }

            }
  
			int sizelist = AnalyzeEngine.DrawsList.Count - 1;
			var numberdraw = AnalyzeEngine.DrawsList [sizelist].DrawNumber.ToString ();
			var lastdatedraw = AnalyzeEngine.DrawsList [sizelist].DrawTime.ToString ();

			DrawNumberlabel.Text = "Τελευταία ανάλυση Κλήρωσης Νο " + numberdraw + " στις " + lastdatedraw;
		}

		void OnGeneratedButtonClicked (object sender, EventArgs e)
		{
			Button button = (Button)sender;
			var statistics = AnalyzeEngine.GetSingleNumberStatistics (button.Text.ToString ());
			DisplayActionSheet ("Αριθμός " + button.Text, "Ok", null, "Σύνολο εμφανίσεων " + statistics.numbercount, "Ποσοστό εμφάνισης " + statistics.percentageshow.ToString () + "%", "Πιθανότητα εμφάνισης " + statistics.possibilitytoshownext.ToString (), "Τελευταία εμφάνιση πριν από " + statistics.countfromlastdraw.ToString () + " Κληρώσεις ", "στις " + statistics.stringlastdrawshowedTime.ToString ());
			//DisplayAlert ("Αριθμός "+button.Text, "Σύνολο εμφανίσεων " + statistics.numbercount + " " + "Ποσοστό εμφάνισης " + statistics.percentageshow.ToString() + " % " + "Πιθανότητα εμφάνισης " + statistics.possibilitytoshownext.ToString() + " Τελευταία εμφάνιση πριν από " + statistics.countfromlastdraw.ToString() + " Κληρώσεις στις " + statistics.stringlastdrawshowedTime.ToString(),"OK");
		}

		async void RefreshButton_Click (object sender, EventArgs e)
		{
			var previousdraws = AnalyzeEngine.DrawsList.Count;

			var tdraws = await SyncService.getTodayDraws ();
			var ydraws = await SyncService.getYesterdayDraws ();
			SyncService.SaveDraws (tdraws, ydraws);	

			int sizelist = AnalyzeEngine.DrawsList.Count - 1;
			var numberdraw = AnalyzeEngine.DrawsList [sizelist].DrawNumber.ToString ();
			var lastdatedraw = AnalyzeEngine.DrawsList [sizelist].DrawTime.ToString ();
			DrawNumberlabel.Text = "Τελευταία ανάλυση Κλήρωσης Νο " + numberdraw + " στις " + lastdatedraw;
			var currentdraws = AnalyzeEngine.DrawsList.Count;

			if (previousdraws == currentdraws) {
				DisplayAlert ("Kino Statistics", "Δεν βρέθηκαν νέες κληρώσεις για δειγματοληψία & ανάλυση. προτείνεται να πατάτε το κουμπί ανανέωση συνήθως 1 με 1.5 λεπτό μετα απο το τέλος κάθε κλήρωσης του kino", "OK");
			}
		}
	}
}

