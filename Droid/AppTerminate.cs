using KinoStatistics.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AppTerminate))]
namespace KinoStatistics.Droid
{
	public class AppTerminate : IAppTerminate
	{
		public void CloseApp()
		{
			Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
		}
	}
}