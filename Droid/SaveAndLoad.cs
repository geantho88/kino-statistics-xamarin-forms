using System;
using System.IO;
using Xamarin.Forms;
using KinoStatistics.Droid;

[assembly: Dependency (typeof (SaveAndLoad))]
namespace KinoStatistics.Droid
{
	public class SaveAndLoad : ISaveAndLoad 
	{
		public void SaveText (string filename, string text) {
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			System.IO.File.WriteAllText (filePath, text);
		}
		public string LoadText (string filename) {
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			return System.IO.File.ReadAllText (filePath);
		}

		public void ClearText(string filename)
		{
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var filePath = Path.Combine (documentsPath, filename);
			File.WriteAllText(filePath, String.Empty);
		}
	}
}

