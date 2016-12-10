
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Event
{
	[Activity(Label = "SplashActivity", Theme = "@style/Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		static readonly string TAG = "X:" + typeof(SplashActivity).Name;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			Log.Debug(TAG, "SplashActivity.OnCreate");
		}

		protected override void OnResume()
		{
			base.OnResume();

			Task startTask = new Task(() => { 
				Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
				Task.Delay(2000);  // Simulate a bit of startup work.
				Log.Debug(TAG, "Working in the background - important stuff.");
			});

			startTask.ContinueWith(t =>
			{
				Log.Debug(TAG, "Work is finished - start Activity1.");
				StartActivity(new Intent(Application.Context, typeof(MainActivity)));
			}, TaskScheduler.FromCurrentSynchronizationContext());

			startTask.Start();
		}
	}
}
