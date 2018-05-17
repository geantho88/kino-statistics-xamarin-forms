using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using KinoStatistics.BusinessLogic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Forms;

namespace KinoStatistics
{
	public partial class BasicMenu : ContentPage
	{
		public BasicMenu ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar (this, false);
			if (AnalyzeEngine.DrawsList.Count == 0) {
				GetSaveData ();
			}


			SizeChanged += (object sender, EventArgs args) => {
				
			};
		}


		async void RandomNumbersBtn_Click (object sender, EventArgs e)
		{
			if (AnalyzeEngine.DrawsList.Count > 0) {
				await Navigation.PushAsync (new RandomNumbers (), true);
			} else {
				await DisplayAlert ("Kino Statistics", "Παρακαλώ περιμένετε. Πραγματοποιείτε λήψη και ανάλυση δεδομένων...", "OK");
			}
		}

		async void AnalyzeDrawsBtn_Click (object sender, EventArgs e)
		{
			if (AnalyzeEngine.DrawsList.Count > 0) {
				await Navigation.PushAsync (new AnalyzeDraws (), true);
			} else {
				await DisplayAlert ("Kino Statistics", "Παρακαλώ περιμένετε. Πραγματοποιείτε λήψη και ανάλυση δεδομένων...", "OK");
			}
		}

		async void ChancesTableBtn_Click (object sender, EventArgs e)
		{
			if (AnalyzeEngine.DrawsList.Count > 0) {
				await Navigation.PushAsync (new DrawsTable (), true);
			} else {
				await DisplayAlert ("Kino Statistics", "Παρακαλώ περιμένετε. Πραγματοποιείτε λήψη και ανάλυση δεδομένων...", "OK");
			}
		}

		async void MyNumbersBtn_Click (object sender, EventArgs e)
		{
			if (AnalyzeEngine.DrawsList.Count > 0) {
				await Navigation.PushAsync (new MyNumbers (), true);
			} else {
				await DisplayAlert ("Kino Statistics", "Παρακαλώ περιμένετε. Πραγματοποιείτε λήψη και ανάλυση δεδομένων...", "OK");
			}
		}

		async void TheGameBtn_Click (object sender, EventArgs e)
		{
			if (AnalyzeEngine.DrawsList.Count > 0) {
				await Navigation.PushAsync (new TheGame (), true);
			} else {
				await DisplayAlert ("Kino Statistics", "Παρακαλώ περιμένετε. Πραγματοποιείτε λήψη και ανάλυση δεδομένων...", "OK");
			}
		}

		async void HelpBtn_Click (object sender, EventArgs e)
		{
			if (AnalyzeEngine.DrawsList.Count > 0) {
				await Navigation.PushAsync (new Help (), true);
			} else {
				await DisplayAlert ("Kino Statistics", "Παρακαλώ περιμένετε. Πραγματοποιείτε λήψη και ανάλυση δεδομένων...", "OK");
			}
		}

		void RefreshButton_Click (object sender, EventArgs e)
		{
			var previousdraws = AnalyzeEngine.DrawsList.Count;
			GetSaveData ();
			var currentdraws = AnalyzeEngine.DrawsList.Count;

			if (previousdraws == currentdraws) {
				DisplayAlert ("Kino Statistics", "Δεν βρέθηκαν νέες κληρώσεις για δειγματοληψία & ανάλυση. προτείνεται να πατάτε το κουμπί ανανέωση συνήθως 1 με 1.5 λεπτό μετα απο το τέλος κάθε κλήρωσης του kino", "OK");
			}
		}

		public async void GetSaveData ()
		{
			try {
				var tdraws = await SyncService.getTodayDraws ();
				var ydraws = await SyncService.getYesterdayDraws ();
				SyncService.SaveDraws (tdraws, ydraws);

				drawlabel1.Text = "Πραγματοποιήθηκε ανάλυση " + AnalyzeEngine.DrawsList.Count ().ToString () + " Κληρώσεων";
				var firstdatedraw = AnalyzeEngine.DrawsList [0].DrawTime.ToString ();
				int sizelist = AnalyzeEngine.DrawsList.Count () - 1;
				var lastdatedraw = AnalyzeEngine.DrawsList [sizelist].DrawTime.ToString ();
				drawlabel2.Text = firstdatedraw + " έως " + lastdatedraw;
			} catch {
                if ((AnalyzeEngine.DrawsList !=null && AnalyzeEngine.DrawsList.Count > 0))
                    await DisplayAlert("Kino Statistics", "Φαίνεται πως κάτι δεν πήγε καλά με τον συγχρονισμό . Παρακαλώ ελέγξτε την συνδεσιμότητα στο ίντερνετ και ξαναδοκιμάστε αργότερα. Τερματισμός...", "OK");
                if (AnalyzeEngine.DrawsList == null || (AnalyzeEngine.DrawsList != null && AnalyzeEngine.DrawsList.Count ==0))
                    {
                  await  DisplayAlert("Kino Statistics", "Οι υπηρεσίες αποτελεσμάτων του παρόχου δεν λειτουργούν προσωρινά. Το Kino Statistics δεν ευθύνεται γι αυτήν την δυσλειτουργία. Παρακαλούμε προσπαθήστε σε λίγο", "OK");
                }
            }
		}
	}
}

