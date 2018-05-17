using System;
using System.Net;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using KinoStatistics.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Collections.ObjectModel;

	namespace KinoStatistics.BusinessLogic
	{
		public class AnalyzeEngine
		{
			public static ObservableCollection<Draw> DrawsList = new ObservableCollection<Draw>();
			public static ObservableCollection<NumberStatistics> NumbersStatisticsList = new ObservableCollection<NumberStatistics>();
			public static ObservableCollection<DrawsPerHour> DrawsPerHour = new ObservableCollection<DrawsPerHour>();

			public static void getSaveDraws(string Datedraws)
			{
				if (!string.IsNullOrEmpty(Datedraws))
				{
				//	System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("el-GR");

					JObject JOResult = (JObject)JObject.Parse(Datedraws)["draws"];
					JArray draws = (JArray)JOResult["draw"];

					foreach (var drawitem in draws)
					{
						Draw draw = new Draw();
						draw.DrawTime = DateTimeFormat(drawitem["drawTime"].ToString());
						draw.DrawNumber = Int64.Parse(drawitem["drawNo"].ToString());

						JArray Results = (JArray)drawitem["results"];

						foreach (var result in Results)
						{
							draw.DrawResults.Add(int.Parse(result.ToString()));
						}

						DrawsList.Add(draw);
					}
				}
			}

			public static Draw getLastDraw(string lastdraw)
			{
				if (!string.IsNullOrEmpty(lastdraw))
				{
				  //	System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("el-GR");

					JObject JOResult = (JObject)JObject.Parse(lastdraw)["draw"];

					Draw draw = new Draw();
					draw.DrawTime = DateTimeFormat(JOResult["drawTime"].ToString());
					draw.DrawNumber = Int64.Parse(JOResult["drawNo"].ToString());

					JArray Results = (JArray)JOResult["results"];

					foreach (var result in Results)
					{
						draw.DrawResults.Add(int.Parse(result.ToString()));
					}

					return draw;

				}

				return null;
			}

			public static void getStatistics()
			{
				ObservableCollection<NumberStatistics> NSList = FillNumberStatistics();

				foreach (var listitem in DrawsList)
				{
					foreach (var number in listitem.DrawResults)
					{
						int entry = NSList.Where(a => a.number == number).Select(a => a.number).SingleOrDefault();
						NSList[entry - 1].numbercount++;
						NSList[entry - 1].lastdrawshowed = DrawsList.IndexOf(listitem);
						NSList[entry - 1].lastdrawshowedTime = listitem.DrawTime.Value;
					}
				}
				int i = 0;
				foreach (var number in NSList)
				{
					NSList[i].numberpercentage = (double)(NSList[i].numbercount / (double)DrawsList.Count) * 100;
					NSList[i].countfromlastdraw = (DrawsList.Count - 1) - NSList[i].lastdrawshowed;
					if (NSList[i].countfromlastdraw >= 6)
					{
						NSList[i].possibilitytoshownext = PossibilityToShow.Υψηλή;
						NSList[i].posibilitytextcolor = "#FFFF0000";
					}
					else if (NSList[i].countfromlastdraw >= 3)
					{
						NSList[i].possibilitytoshownext = PossibilityToShow.Μέτρια;
						NSList[i].posibilitytextcolor = "#FFF5A079";
					}
					else
					{
						NSList[i].possibilitytoshownext = PossibilityToShow.Χαμηλή;
						NSList[i].posibilitytextcolor = "#FF1ADA23";
					}

					i++;
				}

				foreach (var item in NSList)
				{
					NumbersStatisticsList.Add(item);
				}
				//NumbersStatisticsList = NSList;
			}

			private static DateTime? DateTimeFormat(string datetime)
			{
				if (String.IsNullOrEmpty(datetime))
				{
					return null;
				}
				datetime = datetime.Replace("T", " ");
				datetime = datetime.Replace("-", "/");
				return DateTime.Parse(datetime);
			}

			private static Dictionary<int, double> FillFrequencyDictionary()
			{
				Dictionary<int, double> FrequencyNumbers = new Dictionary<int, double>();
				for (int i = 1; i < 81; i++)
				{
					FrequencyNumbers.Add(i, 0);
				}

				return FrequencyNumbers;
			}

			private static ObservableCollection<NumberStatistics> FillNumberStatistics()
			{
				var NumbersList = new ObservableCollection<NumberStatistics>();

				for (int i = 1; i < 81; i++)
				{
					NumberStatistics numberitem = new NumberStatistics();
					numberitem.number = i;
					NumbersList.Add(numberitem);
				}

				return NumbersList;
			}

			public static NumberStatistics GetSingleNumberStatistics(string number)
			{
				NumberStatistics numberstatistics = new NumberStatistics();
				numberstatistics = NumbersStatisticsList.SingleOrDefault(s => s.number == int.Parse(number));
				return numberstatistics;
			}

			public static void GetDrawsByHour()
			{
				for (int i = 9; i <= 22; i++)
				{
					DrawsPerHour drawhour = new DrawsPerHour();
					drawhour.DrawsListPerHour = DrawsList.Where(a => a.DrawTime.Value.Hour == i).ToList();
					drawhour.hour = i;

					DrawsPerHour.Add(drawhour);
				}
			}

			public static List<HourlyNumberStatistics> AnalyzeNumbersbyhour(int hour)
			{
				List<HourlyNumberStatistics> x = CreateHourlynumbers();
				List<Draw> thishourdraws = DrawsPerHour.Where(b => b.hour == hour).Select(b => b.DrawsListPerHour).Single();

				foreach (var entry in thishourdraws)
				{
					for (int i = 0; i <= 79; i++)
					{
						if (entry.DrawResults.Contains(i + 1))
						{
							x[i].count++;
							x[i].stringHours.Add(entry.DrawTime.Value.ToString());
							x[i].totalcounts = thishourdraws.Count();
							x[i].percentage = ((double)x[i].count / (double)x[i].totalcounts) * 100;
						}
					}
				}

				return x;
			}

			public static List<MultipleNumbers> GetMultipleNumbers(string number, int size)
			{
				List<MultipleNumbers> multinumbers = new List<MultipleNumbers>();
				int drawscounter = 0;

				foreach (var drawitem in DrawsList)
				{
					drawscounter++;
					MultipleNumbers mnumber = new MultipleNumbers();
					foreach (var draw in drawitem.DrawResults)
					{
						if (draw.ToString().Length > 1)
						{
							if (draw.ToString().Substring(1, 1).Contains(number))
							{
								mnumber.Numbers.Add(draw.ToString());
							}
						}
						else if (draw.ToString().Contains(number))
						{
							mnumber.Numbers.Add(draw.ToString());
						}

					}
					mnumber.drawTime = drawitem.DrawTime.Value;
					mnumber.drawnumber = drawitem.DrawNumber.ToString();
					mnumber.TotalCount = multinumbers.Count.ToString();
					mnumber.numscount = mnumber.Numbers.Count.ToString();
					int x = DrawsList.Count - drawscounter;
					mnumber.lastdrawshown = x.ToString();
					multinumbers.Add(mnumber);
				}

				return multinumbers.Where(a => a.Numbers.Count >= size).ToList();
			}

			public static List<HourlyNumberStatistics> CreateHourlynumbers()
			{
				List<HourlyNumberStatistics> Hourlynumber = new List<HourlyNumberStatistics>();
				for (int i = 1; i < 81; i++)
				{
					HourlyNumberStatistics number = new HourlyNumberStatistics();
					number.number = i;
					Hourlynumber.Add(number);
				}

				return Hourlynumber;
			}

			public static void getDoubleNumbers()
			{
				List<DoubleNumbersDraw> DnD = new List<DoubleNumbersDraw>();

				foreach (var draw in DrawsList)
				{
					if (DnD.Select(a => a.number.Contains(draw.DrawResults.ToString())).SingleOrDefault())
					{
						var number = DnD.Where(a => a.number == draw.DrawResults.ToString()).SingleOrDefault();
						number.drawsshowed.Add(draw.DrawTime.Value);
					}
					else
					{

					}
				}
			}
		}
	}
	

