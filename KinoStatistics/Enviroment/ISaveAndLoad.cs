using System;

namespace KinoStatistics
{
	public interface ISaveAndLoad {
		void SaveText (string filename, string text);
		string LoadText (string filename);
		void ClearText(string filename);
	}
}

