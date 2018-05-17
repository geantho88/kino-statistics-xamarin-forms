using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Globalization;
using System.Threading;
using Android.Net;
using Android.Util;

namespace KinoStatistics.Droid
{
	[Activity (Label = "Kino Statistics", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			App.ScreenWidth = (int)Resources.DisplayMetrics.WidthPixels; // real pixels
			App.ScreenHeight = (int)Resources.DisplayMetrics.HeightPixels; // real pixels

			var metrics = new DisplayMetrics();
			this.WindowManager.DefaultDisplay.GetMetrics(metrics);

			App.Ydpi = metrics.Ydpi; 
			App.Xdpi = metrics.Xdpi;

			LoadApplication (new App ());

			var userSelectedCulture = new CultureInfo ("el-GR");
			Thread.CurrentThread.CurrentCulture = userSelectedCulture;

		}


	}
}

