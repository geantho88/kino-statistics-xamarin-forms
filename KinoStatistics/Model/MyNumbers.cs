using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace KinoStatistics.Model
{
	public partial class MyNumbers
	{
		public int ID{ get; set;}
		public List<string> Numbers{ get; set; }
	}
}

