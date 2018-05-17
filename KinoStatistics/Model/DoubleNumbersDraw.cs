using System;
using System.Collections.Generic;

namespace KinoStatistics.Model
{
	class DoubleNumbersDraw
	{
		public DoubleNumbersDraw()
		{
			this.drawsshowed = new List<DateTime>();
		}

		public string number { get; set; }
		public List<DateTime> drawsshowed { get; set; }
	}
}
