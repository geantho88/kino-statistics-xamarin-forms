using System;
using System.Collections.Generic;

namespace KinoStatistics.Model
{
	public class MultipleNumbers
	{
		public MultipleNumbers()
		{
			this.Numbers = new List<string>();
		}
		public string TotalCount { get; set; }
		public string numscount { get; set; }
		public DateTime drawTime { get; set; }
		public string drawTimestring { get { return drawTime.ToString(); } set { } }
		public string drawnumber { get; set; }
		public string lastdrawshown { get; set; }
		public List<string> Numbers { get; set; }
	}
}
