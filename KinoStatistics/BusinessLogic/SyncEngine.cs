using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinoStatistics.BusinessLogic;
using System.IO;
using System.Net.Http;


namespace KinoStatistics
{
	public class SyncService
	{
		public static async Task<string> getTodayDraws()
		{			
			HttpClient WBclient = new HttpClient();
			string TodayDrawsurl = "http://applications.opap.gr/DrawsRestServices/kino/drawDate/" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".json";
			return await WBclient.GetStringAsync(new Uri(TodayDrawsurl));
		}

		public static async Task<string> getYesterdayDraws()
		{
			int month = (DateTime.Now.Day == 1) ? DateTime.Now.AddMonths(-1).Month : DateTime.Now.Month;
			HttpClient WBclient = new HttpClient();
			string YesterdayDrawsurl = "http://applications.opap.gr/DrawsRestServices/kino/drawDate/" + DateTime.Now.AddDays(-1).Day + "-" + month + "-" + DateTime.Now.Year + ".json";
			return await WBclient.GetStringAsync(new Uri(YesterdayDrawsurl));
		}

		public static void SaveDraws(string todaysdraws, string yesterdaysdraws)
		{

			if (!String.IsNullOrEmpty(todaysdraws) && (!String.IsNullOrEmpty(yesterdaysdraws)))
			{
				AnalyzeEngine.DrawsList.Clear();
				AnalyzeEngine.NumbersStatisticsList.Clear();
				AnalyzeEngine.getSaveDraws(yesterdaysdraws);
				AnalyzeEngine.getSaveDraws(todaysdraws);
				AnalyzeEngine.getStatistics();
			}
		}

	}
}
	

