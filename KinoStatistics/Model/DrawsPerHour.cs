using System;
using System.Collections.Generic;

namespace KinoStatistics.Model
{
	public class DrawsPerHour
	{
		public DrawsPerHour()
		{
			DrawsListPerHour = new List<Draw>();
		}

		public int hour { get; set; }
		public List<Draw> DrawsListPerHour { get; set; }
	}
}
