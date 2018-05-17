using System;
using System.Collections.Generic;
using System.Text;

namespace KinoStatistics.Model
{
	public class HourlyNumberStatistics
	{
		public HourlyNumberStatistics()
		{
			this.Hours = new List<DateTime>();
			this.stringHours = new List<string>();
		}
		public int number { get; set; }
		public int count { get; set; }
		public List<DateTime> Hours { get; set; }
		public List<string> stringHours { get; set; }
		public int totalcounts { get; set; }
		public double percentage { get; set; }
		public double percentageshow { get { return Math.Round(percentage, 1); } set { } }
		public string numberShow {
			get {
				if (number.ToString ().Length == 1) {
					StringBuilder builder = new StringBuilder ();
					builder.Append ("0").Append (number.ToString ());
					return builder.ToString ();
				}
				return number.ToString ();				
			}
		}
	}
}
