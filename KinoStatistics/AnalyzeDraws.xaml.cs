using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Input;
using KinoStatistics.BusinessLogic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KinoStatistics
{
	public partial class AnalyzeDraws : ContentPage
	{
		public AnalyzeDraws ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			if(AnalyzeEngine.DrawsList.Count > 0)
			{
				int count = AnalyzeEngine.DrawsList.Count;
				analyzedrawlabel1.Text = "Η μηχανή Kino Statistics ανέλυσε " + count + " κληρώσεις, Υπολογίσε εμφανίσεις " + count * 20 + " αριθμών";

				int sizelist = AnalyzeEngine.DrawsList.Count() - 1;
				var lastdrawno =  AnalyzeEngine.DrawsList[sizelist].DrawNumber.ToString();
				var lastdatedraw = AnalyzeEngine.DrawsList[sizelist].DrawTime.ToString();
				analyzedrawlabel2.Text = "Τελευταία κλήρωση που αναλύθηκε : Νο " + lastdrawno + " στις " + lastdatedraw;
			}     
		}

		async void PropabilityButton_Click(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PercentageNumbers(),true);
		}

		async void DisplayButton_Click(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CountNumbers(),true);
		}

		async void NextNumbersButton_Click(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NextNumbers(),true);
		}

		async void EndingNumbersButton_Click(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new VerticalNumbers(),true);
		}

		async void HoursNumberButton_Click(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new HourDraws(),true);
		}
	}
}

