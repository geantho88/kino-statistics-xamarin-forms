using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;

namespace KinoStatistics.Model
{
	public class NumberStatistics
	{
		public int number { get; set; }

		public int numbercount { get; set; }

		public double numberpercentage { get; set; }

		public int lastdrawshowed { get; set; }

		public DateTime lastdrawshowedTime { get; set; }

		public string stringlastdrawshowedTime { get { return lastdrawshowedTime.ToString (); } }

		public int countfromlastdraw { get; set; }

		public PossibilityToShow possibilitytoshownext { get; set; }

		public string posibilitytextcolor { get; set; }

		public Color XamarinPosibilityTextColor {
			get {
				return Color.FromHex (posibilitytextcolor);
			}
		}

		public double percentageshow { get { return Math.Round (numberpercentage, 1); } set { } }

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

	public enum PossibilityToShow
	{
		Υψηλή,
		Μέτρια,
		Χαμηλή
	}
}


