using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace Event
{
	/// <summary>
	/// Splash activity.
	/// </summary>
	[Activity(Label = "EventApp", Theme = "@style/Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		protected override void OnResume()
		{
			base.OnResume();

			Task startTask = new Task(() => { 
				Task.Delay(2000);  //todo here we can get zones collection
			});

			startTask.ContinueWith(t =>
			{
				StartActivity(new Intent(Application.Context, typeof(ZoneActivity)));
			}, TaskScheduler.FromCurrentSynchronizationContext());

			startTask.Start();
		}
	}
}
